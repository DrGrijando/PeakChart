namespace FlowChart.Droid
{
    using Android.App;
    using Android.Content.PM;
    using Android.Runtime;
    using Android.OS;
    using FlowChart.Services;
    using Xamarin.Forms;
    using FlowChart.Views;
    using FlowChart.ViewModels;

    [Activity(Label = "FlowChart", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private INavigationService navigationService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override async void OnBackPressed()
        {
            if (navigationService == null)
                navigationService = DependencyService.Get<NavigationService>();

            if (navigationService.ModalStack.Count > 0)
                await navigationService.GoBack();
            else if (ShouldNavigateToHome())
                await navigationService.NavigateToSectionAsync<HomeViewModel>();
            else
                base.OnBackPressed();
        }

        private bool ShouldNavigateToHome() 
        {
            return navigationService.NavigationStack.Count == 1 
                && navigationService.NavigationStack[0] is MasterPage masterPage 
                && !(masterPage.Detail is HomePage);
        }
    }
}