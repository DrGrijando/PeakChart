using FlowChart.Constants;
using FlowChart.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlowChart.ViewModels
{
    public class AddChartValueViewModel : BaseViewModel
    {
        public string Value { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsNightPeriod { get; set; }

        public Command SaveValueCommand { get; }

        public AddChartValueViewModel() 
        {
            SaveValueCommand = new Command(async () => await SaveValueCommandExecute());
        }

        private async Task SaveValueCommandExecute()
        {
            MessagingCenter.Send(this, MessagingKeys.AddValue, new FlowReading()
            {
                Value = float.Parse(Value),
                Date = Date
            });

            await Shell.Current.Navigation.PopModalAsync();
        }
    }
}
