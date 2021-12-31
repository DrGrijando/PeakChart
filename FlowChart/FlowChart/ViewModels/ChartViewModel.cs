﻿using FlowChart.Constants;
using FlowChart.Database.Models;
using FlowChart.Database.Services;
using FlowChart.Views;
using FlowChart.Views.Modals;
using Microcharts;
using SkiaSharp;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlowChart.ViewModels
{
    public class ChartViewModel : BaseViewModel
    {
        private readonly int monthId;

        private ObservableCollection<ChartEntry> entries;

        public ObservableCollection<ChartEntry> Entries 
        {
            get { return entries; }
            set { SetProperty(ref entries, value); }
        }

        public ICommand AddValueCommand { get; }

        public ChartViewModel(int? monthId = null)
        {
            this.monthId = monthId ?? DatabaseService.CurrentMonth.Id;

            AddValueCommand = new Command(async () => await AddValueCommandExecute());
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            
            List<Reading> readings = await DatabaseService.GetMonthAsync(monthId);
            ObservableCollection<ChartEntry> entries = new ObservableCollection<ChartEntry>();
            foreach (Reading reading in readings)
            {
                entries.Add(CreateChartEntry(reading));
            }
            Entries = entries;
        }

        private async Task AddValueCommandExecute()
        {
            MessagingCenter.Subscribe<AddChartValueViewModel, Reading>(this, MessagingKeys.AddValue, (vm, reading) => 
            {
                MessagingCenter.Unsubscribe<AddChartValueViewModel, Reading>(this, MessagingKeys.AddValue);
                Entries.Add(CreateChartEntry(reading));
            });

            AddChartValuePage page = (AddChartValuePage)await PageFactory.CreatePage<AddChartValuePage>();
            await Shell.Current.Navigation.PushModalAsync(page);
        }

        private ChartEntry CreateChartEntry(Reading reading)
        {
            ChartEntry entry = new ChartEntry(reading.Value) 
            {
                Color = SKColor.Parse(reading.IsNightPeriod ? "#2C041C" : "#FFD200")  
            };
            entry.ValueLabel = reading.Value.ToString();
            entry.Label = reading.Date.ToString("dd/MM");
            
            return entry;
        }
    }
}
