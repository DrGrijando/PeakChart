namespace FlowChart.Views.Modals
{
    using ViewModels;
    using Xamarin.Forms.Xaml;
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddChartValuePage
    {
        public AddChartValuePage(AddChartValueViewModel vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}