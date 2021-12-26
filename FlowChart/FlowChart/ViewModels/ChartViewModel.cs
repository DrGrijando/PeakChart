using FlowChart.Constants;
using FlowChart.Database.Models;
using FlowChart.Models;
using FlowChart.Views.Modals;
using Microcharts;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlowChart.ViewModels
{
    public class ChartViewModel : BaseViewModel
    {
        private ObservableCollection<ChartEntry> entries;
        private Chart chart;

        public ObservableCollection<ChartEntry> Entries 
        {
            get { return entries; }
            set { SetProperty(ref entries, value); }
        }

        public Chart Chart
        {
            get { return chart; }
            set { SetProperty(ref chart, value); }
        }

        public Command AddValueCommand { get; }

        public ChartViewModel() 
        {
            entries = PopulateChart();
            AddValueCommand = new Command(async () => await AddValueCommandExecute());
        }

        private ObservableCollection<ChartEntry> PopulateChart()
        {
            return new ObservableCollection<ChartEntry>
            {
                AddChartEntry(new Reading()
                {
                    Value = 700,
                    IsNightPeriod = false,
                    Date = new System.DateTime(2021, 1, 1)
                }),
                AddChartEntry(new Reading()
                {
                    Value = 720,
                    IsNightPeriod = true,
                    Date = new System.DateTime(2021, 2, 1)
                }),
                AddChartEntry(new Reading()
                {
                    Value = 690,
                    IsNightPeriod = false,
                    Date = new System.DateTime(2021, 3, 1)
                }),
                AddChartEntry(new Reading()
                {
                    Value = 700,
                    IsNightPeriod = true,
                    Date = new System.DateTime(2021, 4, 1)
                }),
                AddChartEntry(new Reading()
                {
                    Value = 710,
                    IsNightPeriod = true,
                    Date = new System.DateTime(2021, 5, 1)
                }),
                AddChartEntry(new Reading()
                {
                    Value = 700,
                    IsNightPeriod = true,
                    Date = new System.DateTime(2021, 6, 1)
                }),
                AddChartEntry(new Reading()
                {
                    Value = 720,
                    IsNightPeriod = false,
                    Date = new System.DateTime(2021, 7, 1)
                }),
                AddChartEntry(new Reading()
                {
                    Value = 710, 
                    IsNightPeriod = true, 
                    Date = new System.DateTime(2021, 8, 1)
                })
            };
        }

        private async Task AddValueCommandExecute()
        {
            MessagingCenter.Subscribe<AddChartValueViewModel, Reading>(this, MessagingKeys.AddValue, (vm, reading) => 
            {
                MessagingCenter.Unsubscribe<AddChartValueViewModel, Reading>(this, MessagingKeys.AddValue);
                Entries.Add(AddChartEntry(reading));
            });

            await Shell.Current.Navigation.PushModalAsync(new AddChartValuePage());
        }

        private ChartEntry AddChartEntry(Reading reading)
        {
            ChartEntry entry = new ChartEntry(reading.Value) 
            {
                Color = SKColor.Parse(reading.IsNightPeriod ? "#FFFFA7" : "#1B2F52")  
            };
            entry.ValueLabel = reading.Value.ToString();
            entry.Label = reading.Date.ToString("dd/MM");
            
            return entry;
        }
    }
}
