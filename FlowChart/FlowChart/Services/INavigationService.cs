using System.Threading.Tasks;

namespace FlowChart.Services
{
    public interface INavigationService
    {
        Task GoBack();
        Task NavigateModalAsync<T>(bool animated = true);
        Task NavigateModalAsync<T>(object parameter, bool animated = true);
        Task NavigateAsync<T>(bool animated = true);
        Task NavigateAsync<T>(object parameter, bool animated = true);
    }
}
