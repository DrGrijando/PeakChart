namespace FlowChart.Views.Base
{
    using ViewModels;
    using Xamarin.Forms;
    
    public class BaseContentPage<TViewModel> : ContentPage where TViewModel : BaseViewModel
    {
        protected TViewModel ViewModel => BindingContext as TViewModel;

        public BaseContentPage(BaseViewModel vm)
        {
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await ViewModel.InitializeAsync();
        }
    }
}
