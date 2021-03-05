using Newtonsoft.Json;
using ResPublica.UILibrary.Api;
using ResPublicaDashboard.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ResPublicaDashboard.Services
{
    public class BattleNetAuthorizationService : IBattleNetAuthorizationService
    {

        private ILoggedInUserModel _loggedInUser;
        private IBattleNetApiHelper _apiHelper;

        public BattleNetAuthorizationService(ILoggedInUserModel loggedInUser, IBattleNetApiHelper apiHelper)
        {
            _loggedInUser = loggedInUser;
            _apiHelper = apiHelper;
        }

        public async Task<bool> LogInWithBattleNetAsync()
        {
            bool isSuccessful = await _apiHelper.AuthorizeAsync();

            if (!isSuccessful)
                return false;

            var token = await _apiHelper.GetAccessTokenAsync();

            if (string.IsNullOrEmpty(token))
                return false;

            var bTag = await _apiHelper.GetBattleTagByTokenAsync(token);
            _loggedInUser.BattleTag = bTag;
            _loggedInUser.Token = token;

            return isSuccessful;
        }
    }
}
