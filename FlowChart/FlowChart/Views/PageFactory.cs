namespace FlowChart.Views
{
    using ViewModels;
    using Modals;
    using Xamarin.Forms;

    public static class PageFactory
    {
        /// <summary>
        /// Creates a page using the specified ViewModel.
        /// </summary>
        /// <typeparam name="T">The ViewModel to use.</typeparam>
        /// <param name="parameter">A parameter to pass to the ViewModel when being created.</param>
        /// <returns></returns>
        public static Page CreatePage<T>(object parameter = null) where T : BaseViewModel
        {
            switch (typeof(T).Name)
            {
                case nameof(HomeViewModel):
                    HomeViewModel homeVm = new HomeViewModel();
                    homeVm.Initialize();
                    return new HomePage(homeVm);

                case nameof(ChartViewModel):
                    ChartViewModel chartVm = new ChartViewModel(parameter);
                    chartVm.Initialize();
                    return new ChartPage(chartVm);

                case nameof(AddChartValueViewModel):
                    AddChartValueViewModel addChartValueViewModel = new AddChartValueViewModel();
                    addChartValueViewModel.Initialize();
                    return new AddChartValuePage(addChartValueViewModel);

                case nameof(MonthListViewModel):
                    MonthListViewModel monthListVm = new MonthListViewModel();
                    monthListVm.Initialize();
                    return new MonthListPage(monthListVm);

                case nameof(MasterFlyoutViewModel):
                    MasterFlyoutViewModel flyoutVm = new MasterFlyoutViewModel();
                    flyoutVm.Initialize();
                    return new MasterPageFlyout(flyoutVm);
                
                case nameof(SettingsViewModel):
                    SettingsViewModel settingsVm = new SettingsViewModel();
                    settingsVm.Initialize();
                    return new SettingsPage(settingsVm);

                default:
                    return null;
            }
        }
    }
}
