namespace FlowChart.ViewModels
{
    using Constants;
    using FlowChart.Database.Models;
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;
    
    public class AddChartValueViewModel : BaseViewModel
    {
        private bool isNightPeriod;

        public string Value { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Note { get; set; }
        
        public bool IsNightPeriod 
        {
            get => isNightPeriod;
            set 
            {
                isNightPeriod = value;
                RaisePropertyChanged("SelectedPeriod");
            }
        }

        public string SelectedPeriod => IsNightPeriod ? "Night" : "Morning";

        public ICommand SaveValueCommand { get; }

        public AddChartValueViewModel() 
        {
            SaveValueCommand = new Command(async () => await SaveValueCommandExecute());
        }

        private async Task SaveValueCommandExecute()
        {
            Reading reading = new Reading()
            {
                Value = int.Parse(Value),
                Date = Date,
                IsNightPeriod = IsNightPeriod,
                Note = Note
            };

            int readingId = await DatabaseService.InsertReadingAsync(reading);

            MessagingCenter.Send(this, MessagingKeys.AddValue, reading);

            await NavigationService.GoBack();
        }
    }
}
