namespace FlowChart.Views
{
    using FlowChart.ViewModels;
    using Base;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : BaseContentPage<HomeViewModel>
    {
        public HomePage(HomeViewModel vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}