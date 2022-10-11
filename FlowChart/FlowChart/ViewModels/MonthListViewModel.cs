namespace FlowChart.ViewModels
{
    using FlowChart.Database.Models;
    using FlowChart.Views;
    using System.Collections.Generic;
    using System.Linq;
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

        public ICommand MonthSelectedCommand { get; }

        public MonthListViewModel() 
        {
            MonthSelectedCommand = new Command(async () => await NavigateToMonthChartAsync());
        }

        /// <summary>
        /// Initializes the ViewModel aspects that need to be done asynchronously.
        /// </summary>
        /// <returns></returns>
        public override async Task InitializeAsync()
        {
            List<ReadingMonth> storedMonths = await DatabaseService.GetMonthsAsync();
            Months = new List<ReadingMonth>(storedMonths.OrderBy(month => month.Year).ThenBy(month => month.Month));

            await base.InitializeAsync();
        }

        private async Task NavigateToMonthChartAsync()
        {
            await NavigationService.NavigateAsync<ChartViewModel>(SelectedMonth.Id);
        }
    }
}
