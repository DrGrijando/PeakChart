namespace FlowChart.ViewModels
{
    using Enums;
    using Models;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MasterFlyoutViewModel : BaseViewModel
    {
        private FlyoutMenuItem selectedMenuItem;
        private Section previousSection;
        
        /// <summary>
        ///     The menu items of the flyout.
        /// </summary>
        public ObservableCollection<FlyoutMenuItem> MenuItems { get; private set; }

        /// <summary>
        ///     The selected menu item of the flyout.
        /// </summary>
        public FlyoutMenuItem SelectedMenuItem
        {
            get => selectedMenuItem;
            set => SetProperty(ref selectedMenuItem, value);
        }
        
        /// <summary>
        ///     The command to execute when a menu item is selected.
        /// </summary>
        public ICommand MenuItemSelectedCommand { get; private set; }

        /// <summary>
        ///     Creates a new instance of the <see cref="MasterFlyoutViewModel"/> class.
        /// </summary>
        public MasterFlyoutViewModel()
        {
            MenuItems = new ObservableCollection<FlyoutMenuItem>(new[]
            {
                    new FlyoutMenuItem { Id = (int)Section.Home, Title = "Home" },
                    new FlyoutMenuItem { Id = (int)Section.Chart, Title = "Chart" },
                    new FlyoutMenuItem { Id = (int)Section.Months, Title = "Months" }
            });


            MenuItemSelectedCommand = new Command(async() => await NavigateAsync());
        }

        private async Task NavigateAsync()
        {
            if (SelectedMenuItem == null)
                return;

            Section selectedSection = (Section)SelectedMenuItem.Id;
            if (selectedSection != previousSection)
            {
                switch(selectedSection)
                {
                    case Section.Home:
                        await NavigationService.NavigateToSectionAsync<HomeViewModel>();
                        break;
                    case Section.Chart:
                        await NavigationService.NavigateToSectionAsync<ChartViewModel>();
                        break;
                    case Section.Months:
                        await NavigationService.NavigateToSectionAsync<MonthListViewModel>();
                        break;
                    default:
                        break;
                }

                previousSection = selectedSection;
            }
            else
            {
                NavigationService.CloseSideMenu();
            }
            
            SelectedMenuItem = null;
        }
    }
}
