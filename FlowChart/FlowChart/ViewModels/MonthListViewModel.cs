using FlowChart.Database.Models;
using FlowChart.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlowChart.ViewModels
{
    public class MonthListViewModel : BaseViewModel
    {
        public List<ReadingMonth> Months { get; set; }

        public ReadingMonth SelectedMonth { get; set; }

        public ICommand MonthSelectedCommand { get; private set; }

        public MonthListViewModel() 
        {
            MonthSelectedCommand = new Command(async () => await NavigateToMonthChartAsync());
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            
            List<ReadingMonth> months = await DatabaseService.GetMonthsAsync();
            Months = months;
        }

        private async Task NavigateToMonthChartAsync()
        {
            ChartPage page = (ChartPage)await PageFactory.CreatePage<ChartPage>(SelectedMonth.Id);
            await Shell.Current.Navigation.PushAsync(page);
        }
    }
}
