namespace FlowChart.ViewModels
{
    using System.Windows.Input;
    using Xamarin.Forms;
    
    public class HomeViewModel : BaseViewModel
    {
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
            Title = "Home";
            
            AddMonthsCommand = new Command(async () => await DatabaseService.InsertNewMonthTest(Month, Year));
        }

        public ICommand AddMonthsCommand { get; }
    }
}