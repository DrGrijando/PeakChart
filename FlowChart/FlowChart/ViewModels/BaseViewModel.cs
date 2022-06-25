namespace FlowChart.ViewModels
{
    using FlowChart.Database.Services;
    using FlowChart.Services;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool isBusy;
        private string title = string.Empty;

        protected DatabaseService DatabaseService { get; }

        protected NavigationService NavigationService { get; }

        public event EventHandler InitializationFinished;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public BaseViewModel()
        {
            DatabaseService = DependencyService.Get<DatabaseService>();
            NavigationService = DependencyService.Get<NavigationService>();
        }

        /// <summary>
        /// Initializes the ViewModel aspects that don't need to be done asynchronously.
        /// </summary>
        public virtual void Initialize() { }

        /// <summary>
        /// Initializes the ViewModel aspects that need to be done asynchronously.
        /// </summary>
        /// <returns></returns>
        public virtual Task InitializeAsync() 
        {
            InitializationFinished?.Invoke(this, null);
            return Task.CompletedTask;
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            RaisePropertyChanged(propertyName);
            return true;
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler changed = PropertyChanged;
            changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
