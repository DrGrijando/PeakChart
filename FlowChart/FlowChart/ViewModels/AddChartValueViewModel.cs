using FlowChart.Constants;
using FlowChart.Database.Models;
using FlowChart.Database.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlowChart.ViewModels
{
    public class AddChartValueViewModel : BaseViewModel
    {
        private readonly DatabaseService databaseService;

        public string Value { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsNightPeriod { get; set; }

        public Command SaveValueCommand { get; }

        public AddChartValueViewModel() 
        {
            databaseService = DependencyService.Get<DatabaseService>();
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

            int readingId = await databaseService.InsertReadingAsync(reading);

            var readings = await databaseService.GetMonthAsync(DateTime.UtcNow);

            reading.Value = 123;
            await databaseService.UpdateReadingAsync(reading);

            readings = await databaseService.GetMonthAsync(DateTime.UtcNow);

            //MessagingCenter.Send(this, MessagingKeys.AddValue, reading);

            await Shell.Current.Navigation.PopModalAsync();
        }
    }
}
