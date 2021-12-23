using FlowChart.ViewModels;
using Microcharts;
using SkiaSharp;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlowChart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChartPage
    {
        private readonly ChartViewModel vm;

        public ChartPage()
        {
            InitializeComponent();
            BindingContext = new ChartViewModel();
            vm = BindingContext as ChartViewModel;

            vm.Entries.CollectionChanged += Entries_CollectionChanged;

            chart.WidthRequest = vm.Entries.Count * 16;
            chart.Chart = new LineChart() 
            {
                MinValue = 500,
                MaxValue = 750,
                PointSize = 30,
                LineSize = 10,
                LineMode = LineMode.Straight,
                EnableYFadeOutGradient = true,
                LabelOrientation = Orientation.Horizontal,
                LabelTextSize = 30,
                ValueLabelOrientation = Orientation.Horizontal,
                Entries = vm.Entries
            };
        }

        ~ChartPage() 
        {
            vm.Entries.CollectionChanged -= Entries_CollectionChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            chart.Chart.IsAnimated = false;
        }

        private void Entries_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            chart.Chart.Entries = vm.Entries;
        }
    }
}