namespace FlowChart.Services
{
    using FlowChart.ViewModels;
    using FlowChart.Views;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class NavigationService : INavigationService
    {
        private MasterPage masterPage => (Application.Current.MainPage as NavigationPage).RootPage as MasterPage;
        private Page currentPage => masterPage.Detail;

        private Page transitionPage = new ContentPage();

        /// <summary>
        ///     The current navigation stack.
        /// </summary>
        public IReadOnlyList<Page> NavigationStack => currentPage.Navigation.NavigationStack;

        /// <summary>
        ///     The current modal stack.
        /// </summary>
        public IReadOnlyList<Page> ModalStack => currentPage.Navigation.ModalStack;

        protected Page CurrentPage
        {
            get { return currentPage; }
            set { masterPage.Detail = value; }
        }

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

        public async Task NavigateToSectionAsync<T>(bool animated = true) where T : BaseViewModel
        {
            Page page = PageFactory.CreatePage<T>(null);

            CurrentPage = transitionPage;
            
            await Task.Delay(200);          
            masterPage.IsPresented = false;

            await Task.Delay(200);
            CurrentPage = page;
        }
    }
}
