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
        private IList<ReadingMonth> months;

        public IList<ReadingMonth> Months
        {
            get => months;
            set => SetProperty(ref months, value);
        }

        public ReadingMonth SelectedMonth { get; set; }

        public ICommand MonthSelectedCommand { get; private set; }

        public MonthListViewModel() 
        {
            MonthSelectedCommand = new Command(async () => await NavigateToMonthChartAsync());
        }

        public override async Task InitializeAsync()
        {
            List<ReadingMonth> months = await DatabaseService.GetMonthsAsync();
            Months = months;

            await base.InitializeAsync();
        }

        private async Task NavigateToMonthChartAsync()
        {
            await NavigationService.NavigateAsync<ChartViewModel>(SelectedMonth.Id);
        }
    }
}
