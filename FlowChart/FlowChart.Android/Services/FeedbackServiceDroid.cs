using System;
using Android.Content;
using FlowChart.Droid.Services;
using Google.Android.Material.Snackbar;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.Dependency(typeof(FeedbackServiceDroid))]
namespace FlowChart.Droid.Services
{
    using Android.App;
    using Android.Widget;
    using FlowChart.Services;
    
    public class FeedbackServiceDroid : IFeedbackService
    {
        /// <summary>
        ///     Shows a toast on screen for a short period of time to give the user a message
        /// </summary>
        /// <param name="message">The message to be shown.</param>
        public void ShowShortToast(string message)
        {
            ShowToast(message, ToastLength.Short);
        }

        /// <summary>
        ///     Shows a toast on screen for a long period of time to give the user a message.
        /// </summary>
        /// <param name="message">The message to be shown.</param>
        public void ShowLongToast(string message)
        {
            ShowToast(message, ToastLength.Long);
        }

        /// <summary>
        ///     Shows a snackbar on screen for a short period of time to give the user a message and allow them to act towards it.
        /// </summary>
        /// <param name="message">The message to be shown.</param>
        /// <param name="action">The text for the action button of the snackbar.</param>
        /// <param name="callback">The callback method for when the action button is pressed.</param>
        public void ShowShortSnackbar(string message, string action = null, Action<object> callback = null)
        {
            ShowSnackbar(message, Snackbar.LengthShort, action, callback);
        }

        /// <summary>
        ///     Shows a snackbar on screen for a long period of time to give the user a message and allow them to act towards it.
        /// </summary>
        /// <param name="message">The message to be shown.</param>
        /// <param name="action">The text for the action button of the snackbar.</param>
        /// <param name="callback">The callback method for when the action button is pressed.</param>
        public void ShowLongSnackbar(string message, string action = null, Action<object> callback = null)
        {
            ShowSnackbar(message, Snackbar.LengthLong, action, callback);
        }

        private void ShowToast(string message, ToastLength length)
        {
            Toast.MakeText(Application.Context, message, length)?.Show();
        }

        private void ShowSnackbar(string message, int length, string action, Action<object> callback)
        {
            var activity = Xamarin.Essentials.Platform.CurrentActivity;
            var activityRootView = activity.FindViewById(Android.Resource.Id.Content);
            
            var snackbar = Snackbar.Make(activityRootView, message, length);
            if (action != null)
                snackbar.SetAction(action, callback);
            
            snackbar.Show();
        }
    }
}