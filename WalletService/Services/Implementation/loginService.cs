using WalletService.Cache;
using WalletService.Data;
using WalletService.Models;
using WalletService.Requests;
using WalletService.Responses;
using WalletService.Services.Interface;
using WalletService.Utilites;
using WalletService.Utilites.Interface;

namespace WalletService.Services.Implementation
{
    public class loginService : ILoginService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICacheService _cacheService;
        private readonly string encrypKey;
        private readonly IMailSender _mailSender;
        public loginService(ApplicationDbContext context, ICacheService cacheService, IMailSender mailSender)
        {
            _context = context;
            _cacheService = cacheService;
            encrypKey = ConfigurationManager.AppSetting["User:EncrypKey"];
            _mailSender = mailSender;
        }
        public async Task<loginResponse> login( loginRequest user)
        {
            loginResponse _response = new loginResponse();
            generator _generator = new generator();

            try
            {
                var checkForUserExist = _context.logins.Where(u => u.userName == user.UserName && u.password == _generator.Encrypt(encrypKey, user.Password)).Any();
                if (checkForUserExist)
                {
                    var userData = _context.logins.Where(u => u.userName == user.UserName && u.password == _generator.Encrypt(encrypKey, user.Password)).FirstOrDefault();

                    if (userData == null)
                    {
                        _response.responseCode = Constants.responseConstant.responseCode05;
                        _response.responseDescription = Constants.responseConstant.responseResponseDescription05;
                    }
                    else if(userData.IsLockedOut == false)
                    {
                        userData.IsLoggedIn = true;
                        userData.lastLoginDate = DateTime.Now;
                        _cacheService.RemoveData("login");
                        _context.Update(userData);
                        var add = await _context.SaveChangesAsync();
                        if (add > 0)
                        {
                            var newSessionId = _generator.generateID();
                            var checkIfUserExistInLogin = _context.logins.Where(u => u.userId == userData.userId).Any();
                            if (checkIfUserExistInLogin)
                            {
                                var getOldSessionTracker = _context.sessionTrackers.Where(u => u.userId == userData.userId && u.userName == userData.userName).FirstOrDefault();
                                if(getOldSessionTracker != null)
                                {
                                    _context.sessionTrackers.Remove(getOldSessionTracker);
                                    _cacheService.RemoveData("sessionTracker");
                                    await _context.SaveChangesAsync();
                                }
                                
                                var addSession = new sessionTracker()
                                {
                                    userId = userData.userId,
                                    userName = userData.userName,
                                    createdDate = DateTime.Now,
                                    sessionId = newSessionId
                                };
                                _context.sessionTrackers.Add(addSession);
                                await _context.SaveChangesAsync();
                                _cacheService.RemoveData("sessionTracker");
                                _response.responseCode = Constants.responseConstant.responseCode00;
                                _response.responseDescription = Constants.responseConstant.responseResponseDescription00;
                                _response.sessionId = newSessionId;
                            }
                            else
                            {
                                _response.responseCode = Constants.responseConstant.responseCode05;
                                _response.responseDescription = Constants.responseConstant.responseResponseDescription05;
                                _response.sessionId = newSessionId;
                            }
                        }


                        else
                        {
                            _response.responseCode = Constants.responseConstant.responseCode05;
                            _response.responseDescription = Constants.responseConstant.responseResponseDescription05;
                        }
                    }
                    else
                    {
                        _response.responseCode = Constants.responseConstant.responseCode05;
                        _response.responseDescription = Constants.responseConstant.responseResponseDescription05;
                    }
                }
                else
                {
                    _response.responseCode = Constants.responseConstant.responseCode06;
                    _response.responseDescription = Constants.responseConstant.responseResponseDescription06;
                }
            }



            catch (Exception ex)
            {

                throw;
            }

            return _response;
        }
        public async Task<loginResponse> logOut(string SessionId)
        {
            loginResponse _response = new loginResponse();
            generator _generator = new generator();

            try
            {
                var getUser = _context.sessionTrackers.Where(u => u.sessionId == SessionId).FirstOrDefault();
                var userData = _context.logins.Where(u => u.userId == getUser.userId).FirstOrDefault();
                
                    
                        userData.IsLoggedIn = false;
                        userData.lastLogOutDate = DateTime.Now;
                        _cacheService.RemoveData("login");
                        _context.Update(userData);
                        _response.responseCode = Constants.responseConstant.responseCode00;
                        _response.responseDescription = Constants.responseConstant.responseResponseDescription00;
            }

            catch (Exception ex)
            {

                throw;
            }

            return _response;
        }

        public async Task<response> resetPassword(string userName)
        {
            response _response = new response();
            generator _generator = new generator();

            try
            {
                var getUser = _context.users.Where(u => u.userName == userName).FirstOrDefault();
                var loginData = _context.logins.Where(u => u.userName == userName).FirstOrDefault();
                var defaultPassword = ConfigurationManager.AppSetting["User:DefaultPassword"];
                string mailSubject = ConfigurationManager.AppSetting["Mailer:Subject"];
                string mailTemplatepath = ConfigurationManager.AppSetting["Mailer:EmailTemplatePath"];


                getUser.password = _generator.Encrypt(encrypKey,defaultPassword);
                loginData.password = getUser.password;
                loginData.IsDefault = true;
                _cacheService.RemoveData("login");
                _context.Update(getUser);
                _cacheService.RemoveData("userInfo");
                _context.Update(loginData);

                //send mail
                var mailBody = System.IO.File.ReadAllText(mailTemplatepath).Replace("{Name}", getUser.firstName+ " " + getUser.lastName).Replace("{password}", defaultPassword);
                await _mailSender.Sendmail(mailSubject, getUser.emailAddress, mailBody, isHtmlFormat: true);
                _response.responseCode = Constants.responseConstant.responseCode00;
                _response.responseDescription = Constants.responseConstant.responseResponseDescription00;
            }

            catch (Exception ex)
            {

                throw;
            }

            return _response;
        }
    }
}
