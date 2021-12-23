using FlowChart.ViewModels;
using Xamarin.Forms.Xaml;

namespace FlowChart.Views.Modals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddChartValuePage
    {
        public AddChartValuePage()
        {
            InitializeComponent();
            BindingContext = new AddChartValueViewModel();
        }
    }
}