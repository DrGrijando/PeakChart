namespace FlowChart.Services
{
    using FlowChart.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public interface INavigationService
    {
        /// <summary>
        ///     The current navigation stack.
        /// </summary>
        IReadOnlyList<Page> NavigationStack{ get; }

        /// <summary>
        ///     The current modal stack.
        /// </summary>
        IReadOnlyList<Page> ModalStack { get; }

        Task GoBack();

        Task NavigateModalAsync<T>(bool animated = true) where T : BaseViewModel;

        Task NavigateModalAsync<T>(object parameter, bool animated = true) where T : BaseViewModel;

        Task NavigateAsync<T>(bool animated = true) where T : BaseViewModel;

        Task NavigateAsync<T>(object parameter, bool animated = true) where T : BaseViewModel;

        Task NavigateToSectionAsync<T>(bool animated = true) where T : BaseViewModel;
    }
}
