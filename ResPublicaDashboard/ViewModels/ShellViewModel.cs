using Caliburn.Micro;
using ResPublicaDashboard.Models;
using ResPublicaDashboard.Models.Events;
using ResPublicaDashboard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResPublicaDashboard.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private readonly IEventAggregator _events;
        private IWindowManager _windowManager;
        private List<IMainScreenTabItem> _tabs;
        private IBattleNetAuthorizationService _bNetAuthService;
        private ILoggedInUserModel _loggedInUser;

        public ShellViewModel(IEventAggregator events, IWindowManager windowManager, IEnumerable<IMainScreenTabItem> tabs,
            IBattleNetAuthorizationService bNetAuthService, ILoggedInUserModel loggedInUser)
        {
            _events = events;
            _windowManager = windowManager;
            _tabs = tabs.ToList();
            _events.SubscribeOnPublishedThread(this);
            _bNetAuthService = bNetAuthService;
            ActivateItemAsync(IoC.Get<SplashViewModel>());
            _loggedInUser = loggedInUser;
            NotifyOfPropertyChange(() => CanLogInWithBnet);
        }

        public async Task LogInWithBnet()
        {
            var isSuccessful = await _bNetAuthService.LogInWithBattleNetAsync();

            if (isSuccessful)
            {
                await ActivateItemAsync(IoC.Get<TabItemsDisplayerViewModel>());
            }
            NotifyOfPropertyChange(() => CanLogOut);
            NotifyOfPropertyChange(() => CanLogInWithBnet);
        }

        public async Task LogOut()
        {
            _loggedInUser.LogOffUser();
            await ActivateItemAsync(IoC.Get<SplashViewModel>());
            NotifyOfPropertyChange(() => CanLogOut);
            NotifyOfPropertyChange(() => CanLogInWithBnet);
        }

        public async Task CloseApplication()
        {
            await TryCloseAsync();
        }

        //public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        //{
        //    await ActivateItemAsync(IoC.Get<TabItemsDisplayerViewModel>());
        //}


        //// ### Properties ###

        public bool CanLogOut
        {
            get
            {
                return !string.IsNullOrEmpty(_loggedInUser.Token);
            }
        }

        public bool CanLogInWithBnet
        {
            get
            {
                return string.IsNullOrEmpty(_loggedInUser.Token);
            }
        }
    }
}
