namespace FlowChart
{
    using Services;
    using Views;
    using System;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public partial class AppShell : Shell
    {
        private readonly NavigationService navigationService;

        public AppShell()
        {
            InitializeComponent();
            navigationService = DependencyService.Get<NavigationService>();
        }

        private async void Chart_Clicked(object sender, EventArgs e)
        {
            await Navigate<ChartPage>();
        }
        private async void Months_Clicked(object sender, EventArgs e)
        {
            await Navigate<MonthListPage>();
        }

        private async Task Navigate<T>()
        {
            await navigationService.NavigateAsync<T>();
            Current.FlyoutIsPresented = false;
        }
    }
}
