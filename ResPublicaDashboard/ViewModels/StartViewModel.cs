using Caliburn.Micro;
using ResPublicaDashboard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResPublicaDashboard.ViewModels
{
    public class StartViewModel : Screen, IMainScreenTabItem
    {
        private ILoggedInUserModel _loggedInUser;
        private ObservableCollection<PlayerComment> _recentlyAddedComments;

        public StartViewModel(ILoggedInUserModel loggedInUser)
        {
            DisplayName = "Start";
            _loggedInUser = loggedInUser;
        }

        public string LoggedInUserName 
        {
            get 
            {
                return _loggedInUser.BattleTag.Substring(0, _loggedInUser.BattleTag.Length - 5);
            } 
        }

        public ObservableCollection<PlayerComment> RecentlyAddedComments
        {
            get 
            { 
                return _recentlyAddedComments; 
            }
        }

        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            // Dummy data for testing. Remove later on when you decide to implement proper soultion.
            _recentlyAddedComments = new ObservableCollection<PlayerComment>()
            {
                new PlayerComment
                {
                    Author = LoggedInUserName,
                    Comment = "Strasznie słaby z niego gracz, nie warto marnować czasu.",
                    Date = DateTime.Now,
                    Nick = "Plebejusz"
                },
                new PlayerComment
                {
                    Author = LoggedInUserName,
                    Comment = "Lorem ipsum bla ",
                    Date = DateTime.Now.Subtract(TimeSpan.FromMinutes(20)),
                    Nick = "Zbygniew1337"
                }
            };

            return base.OnActivateAsync(cancellationToken);
        }
    }
}
