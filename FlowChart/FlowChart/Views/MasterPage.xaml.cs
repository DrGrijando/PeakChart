namespace FlowChart.Views
{
    //using FlowChart.Models;
    //using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : FlyoutPage
    {
        //private MasterPageFlyout flyout;
        public MasterPage()
        {
            InitializeComponent();

            //flyout = (MasterPageFlyout)PageFactory.CreatePage<MasterPageFlyout>();
            
            //Flyout = flyout;

            //flyout.ListView.ItemSelected += ListView_ItemSelected;
        }

        //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var item = e.SelectedItem as FlyoutMenuItem;
        //    if (item == null)
        //        return;

        //    var page = (Page)Activator.CreateInstance(item.TargetType);
        //    page.Title = item.Title;

        //    Detail = new NavigationPage(page);
        //    IsPresented = false;

        //    flyout.ListView.SelectedItem = null;
        //}
    }
}