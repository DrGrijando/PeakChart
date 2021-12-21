using Microcharts;
using SkiaSharp;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlowChart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChartPage : ContentPage
    {
        public ChartPage()
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
                Entries = PopulateChart()
            };
        }

        private ChartEntry[] PopulateChart() 
        {
            return new ChartEntry[]
            {
                AddChartEntry(700, "#FFD200", "Jan"),
                AddChartEntry(720, "#FABADA", "Feb"),
                AddChartEntry(690, "#FFD200", "Mar"),
                AddChartEntry(700, "#FABADA", "Apr"),
                AddChartEntry(700, "#FFD200", "May"),
                AddChartEntry(710, "#FABADA", "Jun"),
                AddChartEntry(720, "#FFD200", "Jul"),
                AddChartEntry(710, "#FABADA", "Aug"),
            };
        }

        private ChartEntry AddChartEntry(float value, string color, string label = null)
        {
            ChartEntry entry = new ChartEntry(value) { Color = SKColor.Parse(color) };

            if (!string.IsNullOrEmpty(label))
            {
                entry.Label = label;
                entry.ValueLabel = value.ToString();
            }

            return entry;
        }
    }
}