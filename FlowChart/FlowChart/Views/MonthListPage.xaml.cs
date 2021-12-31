using FlowChart.ViewModels;
using Xamarin.Forms.Xaml;

namespace FlowChart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonthListPage
    {
        public MonthListPage(MonthListViewModel vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}