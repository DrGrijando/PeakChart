using FlowChart.Views;
using FlowChart.Views.Modals;
using System;
using Xamarin.Forms;

namespace FlowChart
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ChartPage), typeof(ChartPage));
            Routing.RegisterRoute(nameof(AddChartValuePage), typeof(AddChartValuePage));
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            ChartPage page = (ChartPage)await PageFactory.CreatePage<ChartPage>();
            await Current.Navigation.PushAsync(page);
            Current.FlyoutIsPresented = false;
        }
    }
}
