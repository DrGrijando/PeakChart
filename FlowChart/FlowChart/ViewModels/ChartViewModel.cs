namespace FlowChart.ViewModels
{
    using Constants;
    using FlowChart.Database.Models;
    using Views;
    using Views.Modals;
    using Microcharts;
    using SkiaSharp;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;
    
    public class ChartViewModel : BaseViewModel
    {
        private readonly int monthId;

        private ObservableCollection<ChartEntry> entries;

        public ObservableCollection<ChartEntry> Entries 
        {
            get { return entries; }
            set { SetProperty(ref entries, value); }
        }

        public ICommand AddValueCommand { get; }

        public ChartViewModel(object parameter)
        {
            if (parameter is int monthId)
                this.monthId = monthId;

            AddValueCommand = new Command(async () => await AddValueCommandExecute());
        }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            
            List<Reading> readings = await DatabaseService.GetMonthAsync(monthId);
            ObservableCollection<ChartEntry> entries = new ObservableCollection<ChartEntry>();
            foreach (Reading reading in readings)
            {
                entries.Add(CreateChartEntry(reading));
            }
            Entries = entries;
        }

        private async Task AddValueCommandExecute()
        {
            MessagingCenter.Subscribe<AddChartValueViewModel, Reading>(this, MessagingKeys.AddValue, (vm, reading) => 
            {
                MessagingCenter.Unsubscribe<AddChartValueViewModel, Reading>(this, MessagingKeys.AddValue);
                Entries.Add(CreateChartEntry(reading));
            });

            await NavigationService.NavigateModalAsync<AddChartValueViewModel>();
        }

        private ChartEntry CreateChartEntry(Reading reading)
        {
            ChartEntry entry = new ChartEntry(reading.Value) 
            {
                Color = SKColor.Parse(reading.IsNightPeriod ? "#2C041C" : "#FFD200")  
            };
            entry.ValueLabel = reading.Value.ToString();
            entry.Label = reading.Date.ToString("dd/MM");
            
            return entry;
        }
    }
}
