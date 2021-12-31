using FlowChart.ViewModels;
using Xamarin.Forms;

namespace FlowChart.Views.Base
{
    public class BaseContentPage : ContentPage
    {
        public BaseContentPage(BaseViewModel vm)
        {
            BindingContext = vm;
        }
    }
}
