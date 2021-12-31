using FlowChart.Constants;
using FlowChart.Database.Models;
using FlowChart.Database.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlowChart.ViewModels
{
    public class AddChartValueViewModel : BaseViewModel
    {
        public string Value { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsNightPeriod { get; set; }

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
                IsNightPeriod = IsNightPeriod                
            };

            int readingId = await DatabaseService.InsertReadingAsync(reading);

            MessagingCenter.Send(this, MessagingKeys.AddValue, reading);

            await Shell.Current.Navigation.PopModalAsync();
        }
    }
}
