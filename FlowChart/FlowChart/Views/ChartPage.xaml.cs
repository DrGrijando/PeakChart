namespace FlowChart.Views
{
    using ViewModels;
    using Microcharts;
    using Xamarin.Forms.Xaml;
    using FlowChart.Views.Base;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChartPage : BaseContentPage<ChartViewModel>
    {
        public ChartPage(ChartViewModel vm) : base(vm)
        {
            InitializeComponent();
            
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
                Entries = ViewModel.Entries
            };
            chart.WidthRequest = ViewModel.Entries != null ? ViewModel.Entries.Count * 20 : 200;
        }

        ~ChartPage() 
        {
            ViewModel.Entries.CollectionChanged -= Entries_CollectionChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.Entries.CollectionChanged += Entries_CollectionChanged;
            chart.Chart.IsAnimated = false;
        }

        private void Entries_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            chart.Chart.Entries = ViewModel.Entries;
        }
    }
}