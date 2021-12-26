using FlowChart.Database.Services;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FlowChart.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private readonly DatabaseService databaseService;
        public AboutViewModel()
        {
            databaseService = DependencyService.Get<DatabaseService>();
            Title = "About";
            OpenWebCommand = new Command(async () => await databaseService.ClearDatabaseAsync());
        }

        public ICommand OpenWebCommand { get; }
    }
}