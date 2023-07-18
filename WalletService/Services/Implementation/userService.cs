using Microsoft.EntityFrameworkCore;
using WalletService.Cache;
using WalletService.Data;
using WalletService.Models;
using WalletService.Requests;
using WalletService.Responses;
using WalletService.Services.Interface;
using WalletService.Utilites;
using WalletService.Utilites.Implementation;
using WalletService.Utilites.Interface;

namespace WalletService.Services.Implementation
{
    public class userService: IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICacheService _cacheService;
        private readonly string encrypKey;
        private readonly IMailSender _mailSender;
        public userService(ApplicationDbContext context, ICacheService cacheService, IMailSender mailSender) 
        {
            _context = context;
            _cacheService = cacheService;
            encrypKey = ConfigurationManager.AppSetting["User:EncrypKey"];
            _mailSender = mailSender;
        }

        public async Task<response> setUserInfo(userInfo user)
        {
            response _createUserResponse = new response();
            generator _generator = new generator();
            var defaultPassword = ConfigurationManager.AppSetting["User:DefaultPassword"];
            string mailSubject = ConfigurationManager.AppSetting["Mailer:Subject"];
            string mailTemplatepath = ConfigurationManager.AppSetting["Mailer:EmailTemplatePath"];

            //userInfo _user = new userInfo();

            try
            {
                // Check for Existence of records

                var checkForUserName = _context.users.Where(u => u.userName == user.userName).Any();
                var checkForPhoneNo = _context.users.Where(u => u.phoneNo == user.phoneNo).Any();


                if (checkForUserName)
                {
                    _createUserResponse.responseCode = Constants.responseConstant.responseCode01;
                    _createUserResponse.responseDescription = Constants.responseConstant.responseResponseDescription01;
                }
                else if (checkForPhoneNo)
                {
                    _createUserResponse.responseCode = Constants.responseConstant.responseCode02;
                    _createUserResponse.responseDescription = Constants.responseConstant.responseResponseDescription02;
                }

                else
                {
                    user.createdDate = DateTime.Now;
                    user.isActive = false;
                    user.IsDeleted = false;
                    //user.IsLockedOut = false;
                    user.password = _generator.Encrypt(encrypKey, user.password);
                    user.token1 = _generator.tokenGenerator();
                    user.token2 = _generator.tokenGenerator();
                    //_user.
                    _context.users.Add(user);
                    var add = await _context.SaveChangesAsync();

                    _cacheService.RemoveData("userInfo");

                    if (add > 0)
                    {
                        var mailBody = System.IO.File.ReadAllText(mailTemplatepath).Replace("{Name}", user.firstName + " " + user.lastName).Replace("{password}", defaultPassword);
                        _mailSender.Sendmail(mailSubject, user.emailAddress, mailBody);

                        _createUserResponse.responseCode = Constants.responseConstant.responseCode00;
                        _createUserResponse.responseDescription = Constants.responseConstant.responseResponseDescription00;
                        // _createUserResponse.requestId = user.userName;

                    }
                    else
                    {
                        _createUserResponse.responseCode = Constants.responseConstant.responseCode010;
                        _createUserResponse.responseDescription = Constants.responseConstant.responseResponseDescription010;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return _createUserResponse;
        }

        public async Task<response> activateUser(int id, userInfo user)
        {
            response _response = new response();
            generator _generator = new generator();
            try
            {
                var userData = await _context.users.FindAsync(id);

                if (userData == null)
                {
                    _response.responseCode = Constants.responseConstant.responseCode03;
                    _response.responseDescription = Constants.responseConstant.responseResponseDescription03;
                }
                else
                {
                    String[] splited = user.token1.Split("{}");
                    var token1 = splited[0];
                    var token2 = splited[1];

                    var checkForValidToken = _context.users.Where(u => u.token1 == token1 && u.token2 == token2).Any();
                    if (checkForValidToken)
                    {


                        userData.isActive = true;
                        
                       _cacheService.RemoveData("userInfo");
                        _context.Update(userData);
                        var add = await _context.SaveChangesAsync();
                        //var add = await _context.SaveChangesAsync();


                        if (add > 0)
                        {
                            var checkIfUserExistInLogin = _context.logins.Where(u => u.userId == userData.userId).Any();
                            if (!checkIfUserExistInLogin) 
                            {
                                var addLogin = new login()
                                {
                                    userId = userData.userId,
                                    userName = userData.userName,
                                    password = userData.password,
                                    roleId = userData.roleId,
                                    createdDate = DateTime.Now,
                                    isActive = true,
                                    IsLoggedIn = false,
                                    IsLockedOut = false,
                                };
                                _context.logins.Add(addLogin);
                                await _context.SaveChangesAsync();
                                _cacheService.RemoveData("login");
                                
                            }

                           

                            _response.responseCode = Constants.responseConstant.responseCode00;
                            _response.responseDescription = Constants.responseConstant.responseResponseDescription00;
                            // _createUserResponse.requestId = user.userName;

                        }
                        else
                        {
                            _response.responseCode = Constants.responseConstant.responseCode010;
                            _response.responseDescription = Constants.responseConstant.responseResponseDescription010;
                        }
                    }
                    else
                    {
                        _response.responseCode = Constants.responseConstant.responseCode04;
                        _response.responseDescription = Constants.responseConstant.responseResponseDescription04;
                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return _response;
        }
     

    }
}
