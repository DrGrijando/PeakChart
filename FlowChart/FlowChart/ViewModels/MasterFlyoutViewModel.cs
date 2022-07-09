namespace FlowChart.ViewModels
{
    using FlowChart.Enums;
    using FlowChart.Models;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MasterFlyoutViewModel : BaseViewModel
    {
        public ObservableCollection<FlyoutMenuItem> MenuItems { get; set; }

        public ICommand MenuItemSelectedCommand { get; private set; }

        public MasterFlyoutViewModel()
        {
            MenuItems = new ObservableCollection<FlyoutMenuItem>(new[]
            {
                    new FlyoutMenuItem { Id = (int)Section.Home, Title = "Home" },
                    new FlyoutMenuItem { Id = (int)Section.Chart, Title = "Chart" },
                    new FlyoutMenuItem { Id = (int)Section.Months, Title = "Months" }
            });


            MenuItemSelectedCommand = new Command<FlyoutMenuItem>(async (item) => await NavigateAsync(item));
        }

        private async Task NavigateAsync(FlyoutMenuItem item)
        {
            switch((Section)item.Id)
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
        }
    }
}
