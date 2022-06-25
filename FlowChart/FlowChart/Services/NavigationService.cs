namespace FlowChart.Services
{
    using FlowChart.ViewModels;
    using FlowChart.Views;
    using System.Linq;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class NavigationService : INavigationService
    {
        private Page CurrentPage => ((Application.Current.MainPage as NavigationPage).RootPage as MasterPage).Detail;

        public async Task GoBack()
        {
            if (CurrentPage.Navigation.ModalStack.Any())
                await CurrentPage.Navigation.PopModalAsync();
            else
                await CurrentPage.Navigation.PopAsync();
        }

        public async Task NavigateAsync<T>(bool animated = true) where T : BaseViewModel
        {
            await NavigateAsync<T>(null, animated);
        }

        public async Task NavigateAsync<T>(object parameter, bool animated = true) where T : BaseViewModel
        {
            Page page = PageFactory.CreatePage<T>(parameter);
            await CurrentPage.Navigation.PushAsync(page, animated);
        }

        public async Task NavigateModalAsync<T>(bool animated = true) where T : BaseViewModel
        {
            await NavigateModalAsync<T>(null, animated);
        }

        public async Task NavigateModalAsync<T>(object parameter, bool animated = true) where T : BaseViewModel
        {
            Page page = PageFactory.CreatePage<T>(parameter);
            await CurrentPage.Navigation.PushModalAsync(page, animated);
        }
    }
}
