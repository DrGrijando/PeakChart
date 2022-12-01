using System.Threading.Tasks;
using FlowChart.Services;

namespace FlowChart.ViewModels
{
    using System.Windows.Input;
    using Xamarin.Forms;
    
    public class HomeViewModel : BaseViewModel
    {
        private readonly IFeedbackService feedbackService;
        
        private bool showDeveloperFunctions;
        
        public int Month { get; set; }
        public int Year { get; set; }
        
        public bool ShowDeveloperFunctions
        {
            get => showDeveloperFunctions;
            set => SetProperty(ref showDeveloperFunctions, value);
        }

        public HomeViewModel()
        {
            feedbackService = DependencyService.Get<IFeedbackService>();
            
            Title = "Home";
            
            AddMonthsCommand = new Command(async () => await AddMonthsCommandExecuteAsync());
        }

        public ICommand AddMonthsCommand { get; }

        private async Task AddMonthsCommandExecuteAsync()
        {
            await DatabaseService.InsertNewMonthTest(Month, Year);
            feedbackService.ShowLongSnackbar($"Month {Month}/{Year} has been added to the database.", "+1", obj => AddPreviousMonth());
        }

        private async Task AddPreviousMonth()
        {
            var previousMonth = Month - 1;
            
            await DatabaseService.InsertNewMonthTest(previousMonth, Year);
            feedbackService.ShowShortToast($"Month {previousMonth}/{Year} has been added to the database.");
        }
    }
}