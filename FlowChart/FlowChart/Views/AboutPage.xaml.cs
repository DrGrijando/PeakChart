namespace FlowChart.Views
{
    using FlowChart.ViewModels;
    using Base;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : BaseContentPage<AboutViewModel>
    {
        public AboutPage(AboutViewModel vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}