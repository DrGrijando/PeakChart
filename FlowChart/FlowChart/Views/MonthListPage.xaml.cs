namespace FlowChart.Views
{
    using FlowChart.Views.Base;
    using ViewModels;
    using Xamarin.Forms.Xaml;
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonthListPage : BaseContentPage<MonthListViewModel>
    {
        public MonthListPage(MonthListViewModel vm) : base(vm)
        {
            InitializeComponent();

            months.SelectionChanged += Months_SelectionChanged;
        }

        ~MonthListPage()
        {
            months.SelectionChanged -= Months_SelectionChanged;
        }

        private void Months_SelectionChanged(object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            // Doing this the ugly way because the CollectionView
            // won't let go the selected month through binding :_)
            if (months.SelectedItem != null)
            {
                ViewModel.MonthSelectedCommand.Execute(null);
                months.SelectedItem = null;
            }
        }
    }
}