namespace FlowChart.Views.Base
{
    using ViewModels;
    using Xamarin.Forms;
    
    public class BaseContentPage : ContentPage
    {
        public BaseContentPage(BaseViewModel vm)
        {
            BindingContext = vm;
        }
    }
}
