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

        public int Month { get; set; }
        public int Year { get; set; }

        public AboutViewModel()
        {
            databaseService = DependencyService.Get<DatabaseService>();
            Title = "About";
            OpenWebCommand = new Command(async () => await databaseService.ClearDatabaseAsync());

            AddMonthsCommand = new Command(async () => await DatabaseService.InsertNewMonthTest(Month, Year));
        }

        public ICommand OpenWebCommand { get; }

        public ICommand AddMonthsCommand { get; }
    }
}