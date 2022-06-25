namespace FlowChart
{
    using FlowChart.Database.Services;
    using FlowChart.ViewModels;
    using FlowChart.Views;
    using Services;
    using Xamarin.Forms;
    
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            RegisterServices();

            MasterPage masterPage = new MasterPage
            {
                Flyout = PageFactory.CreatePage<MasterFlyoutViewModel>(),
                Detail = PageFactory.CreatePage<HomeViewModel>()
            };

            MainPage = new NavigationPage(masterPage);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void RegisterServices()
        {
            DependencyService.Register<DatabaseService>();
            DependencyService.Register<NavigationService>();
            DependencyService.Register<MockDataStore>();
        }
    }
}
