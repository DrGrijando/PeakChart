using FlowChart.ViewModels;
using FlowChart.Views.Modals;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlowChart.Views
{
    public static class PageFactory
    {
        public static async Task<Page> CreatePage<T>()
        {
            switch (typeof(T).Name)
            {
                case nameof(ChartPage):
                    ChartViewModel vm = new ChartViewModel();
                    await vm.Initialize();
                    return new ChartPage(vm);
                case nameof(AddChartValuePage): 
                    return new AddChartValuePage(new AddChartValueViewModel());
                default: 
                    return null;
            }
        }
    }
}
