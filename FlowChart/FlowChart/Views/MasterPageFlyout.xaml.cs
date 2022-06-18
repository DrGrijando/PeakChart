namespace FlowChart.Views
{
    using FlowChart.ViewModels;
    using FlowChart.Views.Base;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPageFlyout : BaseContentPage<MasterFlyoutViewModel>
    {
        public MasterPageFlyout(MasterFlyoutViewModel vm) : base(vm)
        {
            InitializeComponent();
        }

        //class FlyoutPageFlyoutViewModel : INotifyPropertyChanged
        //{
        //    public event PropertyChangedEventHandler PropertyChanged;
        //    void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //    {
        //        if (PropertyChanged == null)
        //            return;

        //        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    }            
        //}
    }
}