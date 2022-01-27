using FlowChart.ViewModels;
using Xamarin.Forms.Xaml;

namespace FlowChart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonthListPage
    {
        private readonly MonthListViewModel vm;

        public MonthListPage(MonthListViewModel vm) : base(vm)
        {
            InitializeComponent();
            this.vm = vm;

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
                vm.MonthSelectedCommand.Execute(null);
                months.SelectedItem = null;
            }
        }
    }
}