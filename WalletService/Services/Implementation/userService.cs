using Microsoft.AspNetCore.Mvc;
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
                    user.walletAccount = _generator.RandomDigits(10);
                    //user.IsLockedOut = false;
                    if(user.roleId == 1 || user.roleId ==2)
                    {
                       user.password = _generator.Encrypt(encrypKey, user.password);

                    }
                    else
                    {
                        user.password = _generator.Encrypt(encrypKey, defaultPassword);
                    }
                    user.userToken = _generator.RandomDigits(6);
                    

                    
                    user.SuperSimToken = _generator.RandomDigits(6);
                    //_user.
                    _context.users.Add(user);
                    var add = await _context.SaveChangesAsync();

                    _cacheService.RemoveData("userInfo");

                    if (add > 0)
                    {
                        var addBalance = new balanceInfo()
                        {
                            userId = user.userId,
                            walletAccount = user.walletAccount,
                            status = "A",
                            dataBalance = 0,
                            airtimeBalance = 0,
                            createdDate = DateTime.Now,
                            serviceProvider = user.serviceProvider
                            //telcoWalletAccount = user.superSimPhoneNo
                        };
                        _context.balance.Add(addBalance);
                        await _context.SaveChangesAsync();
                        _cacheService.RemoveData("balanceInfo");



                        

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

        public async Task<response> activateUser(activateUserRequest activateUserRequest)
        {
            response _response = new response();
            generator _generator = new generator();
            
            try
            {
                var userData = await  _context.users.Where(u => u.userName == activateUserRequest.userName).FirstOrDefaultAsync();

                if (userData == null)
                {
                    _response.responseCode = Constants.responseConstant.responseCode03;
                    _response.responseDescription = Constants.responseConstant.responseResponseDescription03;
                }
                else
                {
                    if (userData.roleId == 1 || userData.roleId ==2)
                    {
                        //String[] splited = activateUserRequest.tokens.Split("{}");
                        //var userToken = splited[0];
                        //var SuperSimToken = splited[1];
                        string userToken = activateUserRequest.tokens.Substring(0, 6);
                        string SuperSimToken = activateUserRequest.tokens.Substring(6);

                        var checkForValidToken = _context.users.Where(u => u.userToken == userToken && u.SuperSimToken == SuperSimToken).Any();
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
                    else
                    {

                        var checkForValidToken = _context.users.Where(u => u.userToken == activateUserRequest.tokens).Any();
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
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return _response;
        }

        public async Task<userInfo> fetchDealerDetails(int userId)
        {
            var userCache = new userInfo();
            var userCacheList = new List<userInfo>();
            try
            {
               
                userCacheList = _cacheService.GetData<List<userInfo>>("userInfo");
                userCache = userCacheList.Find(x => x.userId == userId);
                if (userCache == null)
                {
                    userCache = await _context.users.FindAsync(userId);
                }
               
            }
            catch (Exception ex)
            {

                throw;
            }
            return userCache;
        }

        public async Task<balanceInfo> fetchDealerAirtimeBalance(int userId)
        {
            var balanceCache = new balanceInfo();
            var balanceCacheList = new List<balanceInfo>();
            try
            {

                balanceCacheList = _cacheService.GetData<List<balanceInfo>>("balanceInfo");
                balanceCache = balanceCacheList.Find(x => x.userId == userId);
                if (balanceCache == null)
                {
                    balanceCache = await _context.balance.FindAsync(userId);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return balanceCache;
        }

        public async Task<transactionLog> getDealerTransactionHistory(int userId)
        {
            var transactionCache = new transactionLog();
            var transactionCacheList = new List<transactionLog>();
            try
            {

                transactionCacheList = _cacheService.GetData<List<transactionLog>>("transactionLog");
                transactionCache = transactionCacheList.Find(x => x.userId == userId);
                if (transactionCache == null)
                {
                    transactionCache = await _context.transactionLogs.FindAsync(userId);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return transactionCache;
        }

        public async Task<response> deactivateUser(int id)
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
                   

                        var validUser = _context.users.Where(u => u.userId == id).Any();
                        if (validUser)
                        {


                            userData.isActive = false;

                            _cacheService.RemoveData("userInfo");
                            _context.Update(userData);
                            var add = await _context.SaveChangesAsync();
                            //var add = await _context.SaveChangesAsync();


                            if (add > 0)
                            {
                                var checkIfUserExistInLogin = _context.logins.Where(u => u.userId == userData.userId).FirstOrDefault();
                                if (checkIfUserExistInLogin != null)
                                {
                                checkIfUserExistInLogin.isActive = false;
                                _cacheService.RemoveData("login");
                                _context.Update(checkIfUserExistInLogin);
                                var update = await _context.SaveChangesAsync();
                                   

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
                            _response.responseCode = Constants.responseConstant.responseCode07;
                            _response.responseDescription = Constants.responseConstant.responseResponseDescription07;
                        }
                    }


                
            }
            catch (Exception ex)
            {

                throw;
            }

            return _response;
        }

        public async Task<userInfo> getListOfUsers(int userId)
        {
            var userCache = new userInfo();
            var userCacheList = new List<userInfo>();
            try
            {

                userCacheList = _cacheService.GetData<List<userInfo>>("userInfo");
                userCache = userCacheList.Find(x => x.createdBy == userId);
                if (userCache == null)
                {
                    userCache = await _context.users.FindAsync(userId);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return userCache;
        }
    }
}
