namespace FlowChart.Views.Modals
{
    using FlowChart.Views.Base;
    using ViewModels;
    using Xamarin.Forms.Xaml;
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddChartValuePage : BaseContentPage<AddChartValueViewModel>
    {
        public AddChartValuePage(AddChartValueViewModel vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}