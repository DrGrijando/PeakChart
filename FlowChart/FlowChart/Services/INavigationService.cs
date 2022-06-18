namespace FlowChart.Services
{
    using FlowChart.ViewModels;
    using System.Threading.Tasks;

    public interface INavigationService
    {
        Task GoBack();
        Task NavigateModalAsync<T>(bool animated = true) where T : BaseViewModel;
        Task NavigateModalAsync<T>(object parameter, bool animated = true) where T : BaseViewModel;
        Task NavigateAsync<T>(bool animated = true) where T : BaseViewModel;
        Task NavigateAsync<T>(object parameter, bool animated = true) where T : BaseViewModel;
    }
}
