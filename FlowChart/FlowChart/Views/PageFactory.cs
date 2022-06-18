namespace FlowChart.Views
{
    using ViewModels;
    using Modals;
    using Xamarin.Forms;

    public static class PageFactory
    {
        /// <summary>
        /// Creates a page of the specified type.
        /// </summary>
        /// <typeparam name="T">The page type to be created.</typeparam>
        /// <param name="parameter">A parameter to pass to the page ViewModel when being created.</param>
        /// <returns></returns>
        public static Page CreatePage<T>(object parameter = null)
        {
            switch (typeof(T).Name)
            {
                case nameof(AboutPage):
                    AboutViewModel aboutVm = new AboutViewModel();
                    aboutVm.Initialize();
                    return new AboutPage(aboutVm);

                case nameof(ChartPage):
                    ChartViewModel chartVm = new ChartViewModel(parameter);
                    chartVm.Initialize();
                    return new ChartPage(chartVm);

                case nameof(AddChartValuePage):
                    AddChartValueViewModel addChartValueViewModel = new AddChartValueViewModel();
                    addChartValueViewModel.Initialize();
                    return new AddChartValuePage(addChartValueViewModel);

                case nameof(MonthListPage):
                    MonthListViewModel monthListVm = new MonthListViewModel();
                    monthListVm.Initialize();
                    return new MonthListPage(monthListVm);

                default: 
                    return null;
            }
        }
    }
}
