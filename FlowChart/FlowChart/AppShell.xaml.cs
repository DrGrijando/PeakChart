namespace FlowChart
{
    using Views;
    using System;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
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
            await Current.Navigation.PushAsync(await PageFactory.CreatePage<T>());
            Current.FlyoutIsPresented = false;
        }
    }
}
