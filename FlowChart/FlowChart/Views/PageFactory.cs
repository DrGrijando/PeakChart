namespace FlowChart.Views
{
    using ViewModels;
    using Modals;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    
    public static class PageFactory
    {
        public static async Task<Page> CreatePage<T>(int? monthId = null)
        {
            switch (typeof(T).Name)
            {
                case nameof(ChartPage):
                    ChartViewModel chartVm = new ChartViewModel(monthId);
                    await chartVm.Initialize();
                    return new ChartPage(chartVm);

                case nameof(AddChartValuePage): 
                    return new AddChartValuePage(new AddChartValueViewModel());

                case nameof(MonthListPage):
                    MonthListViewModel monthListVm = new MonthListViewModel();
                    await monthListVm.Initialize();
                    return new MonthListPage(monthListVm);

                default: 
                    return null;
            }
        }
    }
}
