using Caliburn.Micro;
using ResPublicaDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResPublicaDashboard.ViewModels
{
    public class TabItemsDisplayerViewModel : Conductor<object>.Collection.OneActive
    {
        private readonly IEventAggregator _events;
        private IWindowManager _windowManager;
        private List<IMainScreenTabItem> _tabs;
        private ILoggedInUserModel _loggedInUser;

        public TabItemsDisplayerViewModel(IWindowManager windowManager, IEventAggregator events, IEnumerable<IMainScreenTabItem> tabs, ILoggedInUserModel loggedInUser)
        {
            _windowManager = windowManager;
            _events = events;
            _tabs = tabs.ToList();
            _events.SubscribeOnPublishedThread(this);
            _loggedInUser = loggedInUser;
        }

        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            Items.AddRange(_tabs);
            return base.OnActivateAsync(cancellationToken);
        }


        public string LoggedInUserName
        {
            get 
            { 
                return _loggedInUser.BattleTag; 
            }
        }

    }
}
