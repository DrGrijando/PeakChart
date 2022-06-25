namespace FlowChart.Views.Base
{
    using System.Threading.Tasks;
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

            // Await for page navigation to complete its animation
            await Task.Delay(200);
            await ViewModel.InitializeAsync();
        }
    }
}
