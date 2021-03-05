using System;
using System.Collections.Generic;
using System.Text;

namespace ResPublicaDashboard.Models
{
    public class LoggedInUserModel : ILoggedInUserModel
    {
        public string BattleTag { get; set; }
        public string Token { get; set; }

        public void LogOffUser()
        {
            BattleTag = "";
            Token = "";
        }
    }
}
