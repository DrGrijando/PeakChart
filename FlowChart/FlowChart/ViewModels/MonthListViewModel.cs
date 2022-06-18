namespace FlowChart.ViewModels
{
    using FlowChart.Database.Models;
    using FlowChart.Views;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MonthListViewModel : BaseViewModel
    {
        public List<ReadingMonth> Months { get; set; }

        public ReadingMonth SelectedMonth { get; set; }

        public ICommand MonthSelectedCommand { get; private set; }

        public MonthListViewModel() 
        {
            MonthSelectedCommand = new Command(async () => await NavigateToMonthChartAsync());
        }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            
            List<ReadingMonth> months = await DatabaseService.GetMonthsAsync();
            Months = months;
        }

        private async Task NavigateToMonthChartAsync()
        {
            ChartPage page = (ChartPage)PageFactory.CreatePage<ChartPage>(SelectedMonth.Id);
            await Shell.Current.Navigation.PushAsync(page);
        }
    }
}
