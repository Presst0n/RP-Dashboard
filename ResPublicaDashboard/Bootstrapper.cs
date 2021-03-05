using Caliburn.Micro;
using ResPublica.UILibrary.Api;
using ResPublicaDashboard.Models;
using ResPublicaDashboard.Services;
using ResPublicaDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ResPublicaDashboard
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container.Instance(_container);

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<ILoggedInUserModel, LoggedInUserModel>()
                .Singleton<IBattleNetApiHelper, BattleNetApiHelper>()
                .PerRequest<IBattleNetAuthorizationService, BattleNetAuthorizationService>()
                .PerRequest<IMainScreenTabItem, StartViewModel>()
                .PerRequest<IMainScreenTabItem, RecruitmentViewModel>();

            //ConventionManager.AddElementConvention<PasswordBox>(
            //    PasswordBoxHelper.BoundPasswordProperty,
            //    "Password",
            //    "PasswordChanged");

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .Where(type => type.GetInterface(typeof(IMainScreenTabItem).Name) == null)
                .ToList()
                .ForEach(viewModelType => _container
                .RegisterPerRequest(viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
