using FlowChart.ViewModels;
using Microcharts;
using Xamarin.Forms.Xaml;

namespace FlowChart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChartPage
    {
        private readonly ChartViewModel vm;

        public ChartPage(ChartViewModel vm) : base(vm)
        {
            InitializeComponent();
            this.vm = vm;

            vm.Entries.CollectionChanged += Entries_CollectionChanged;

            chart.Chart = new LineChart()
            {
                MinValue = 500,
                MaxValue = 750,
                PointSize = 30,
                LineSize = 10,
                LineMode = LineMode.Straight,
                EnableYFadeOutGradient = true,
                LabelOrientation = Orientation.Vertical,
                LabelTextSize = 30,
                ValueLabelOrientation = Orientation.Vertical,
                Entries = vm.Entries
            };
            chart.WidthRequest = vm.Entries != null ? vm.Entries.Count * 20 : 200;
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