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
    }
}
