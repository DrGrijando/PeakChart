using FlowChart.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlowChart.Services
{
    public class NavigationService : INavigationService
    {
        private Page MainPage => Application.Current.MainPage;

        public async Task GoBack()
        {
            await MainPage.Navigation.PopAsync();
        }

        public async Task NavigateAsync<T>(bool animated = true)
        {
            await NavigateAsync<T>(null, animated);
        }

        public async Task NavigateAsync<T>(object parameter, bool animated = true)
        {
            Page page = PageFactory.CreatePage<T>(parameter);
            await MainPage.Navigation.PushAsync(page, animated);
        }

        public async Task NavigateModalAsync<T>(bool animated = true)
        {
            await NavigateModalAsync<Tab>(null, animated);
        }

        public async Task NavigateModalAsync<T>(object parameter, bool animated = true)
        {
            Page page = PageFactory.CreatePage<T>(parameter);
            await MainPage.Navigation.PushModalAsync(page, animated);
        }
    }
}
