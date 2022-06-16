namespace FlowChart
{
    using FlowChart.Database.Services;
    using Services;
    using Xamarin.Forms;
    
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<DatabaseService>();
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
    }
}
