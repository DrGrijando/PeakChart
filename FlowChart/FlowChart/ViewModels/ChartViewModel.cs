using FlowChart.Views.Modals;
using Microcharts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlowChart.ViewModels
{
    public class ChartViewModel : BaseViewModel
    {
        private ChartEntry[] entries;
        private Chart chart;

        public ChartEntry[] Entries 
        {
            get { return entries; }
            set { SetProperty(ref entries, value); }
        }

        public Chart Chart
        {
            get { return chart; }
            set { SetProperty(ref chart, value); }
        }

        public Command AddValueCommand { get; }

        public ChartViewModel() 
        {
            AddValueCommand = new Command(async () => await AddValueCommandExecute());
        }

        private async Task AddValueCommandExecute()
        {
            await Shell.Current.Navigation.PushModalAsync(new AddChartValuePage());
        }
    }
}
