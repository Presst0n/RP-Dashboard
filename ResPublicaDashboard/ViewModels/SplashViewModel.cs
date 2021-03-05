using Caliburn.Micro;
using ResPublicaDashboard.Models.Events;
using ResPublicaDashboard.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResPublicaDashboard.ViewModels
{
    public class SplashViewModel : Screen
    {
        private IBattleNetAuthorizationService _bNetAuthService;
        private readonly IEventAggregator _events;

        public SplashViewModel(IBattleNetAuthorizationService bNetAuthService, IEventAggregator events)
        {
            _bNetAuthService = bNetAuthService;
            _events = events;
        }

        //public async Task LogInWithBnet()
        //{
        //    if (await _bNetAuthService.LogInWithBattleNetAsync())
        //    {
        //        await _events.PublishOnUIThreadAsync(new LogOnEvent());
        //    }
        //}
    }
}
