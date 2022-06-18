namespace FlowChart
{
    using FlowChart.Database.Services;
    using FlowChart.Views;
    using Services;
    using Xamarin.Forms;
    
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            RegisterServices();


            MainPage = PageFactory.CreatePage<AboutPage>();
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
