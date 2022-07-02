namespace FlowChart.Views
{
    using ViewModels;
    using Microcharts;
    using Xamarin.Forms.Xaml;
    using FlowChart.Views.Base;
    using System.Threading.Tasks;
    using System;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChartPage : BaseContentPage<ChartViewModel>
    {
        public ChartPage(ChartViewModel vm) : base(vm)
        {
            InitializeComponent();
            
            chart.Chart = new LineChart()
            {
                MinValue = 500,
                MaxValue = 780,
                PointSize = 30,
                LineSize = 8,
                LineMode = LineMode.Spline,
                EnableYFadeOutGradient = true,
                LabelOrientation = Orientation.Vertical,
                LabelTextSize = 30,
                ValueLabelOrientation = Orientation.Vertical,
                AnimationDuration = TimeSpan.FromMilliseconds(1000)
            };

            vm.InitializationFinished += ViewModel_InitializationFinished;
        }

        ~ChartPage() 
        {
            ViewModel.Entries.CollectionChanged -= Entries_CollectionChanged;
        }

        private async void ViewModel_InitializationFinished(object sender, System.EventArgs e)
        {
            ViewModel.Entries.CollectionChanged += Entries_CollectionChanged;

            chart.WidthRequest = ViewModel.Entries.Count * 20;
            chart.Chart.Entries = ViewModel.Entries;

            await Task.Delay(chart.Chart.AnimationDuration);
            chart.Chart.IsAnimated = false;
        }

        private void Entries_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            chart.Chart.Entries = ViewModel.Entries;
        }
    }
}