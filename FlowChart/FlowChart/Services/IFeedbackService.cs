using System;
using FlowChart.Enums;

namespace FlowChart.Services
{
    public interface IFeedbackService
    {
        /// <summary>
        ///     Shows a toast on screen for a short period of time to give the user a message
        /// </summary>
        /// <param name="message">The message to be shown.</param>
        void ShowShortToast(string message);
        
        /// <summary>
        ///     Shows a toast on screen for a long period of time to give the user a message.
        /// </summary>
        /// <param name="message">The message to be shown.</param>
        void ShowLongToast(string message);

        /// <summary>
        ///     Shows a snackbar on screen for a short period of time to give the user a message and allow them to act towards it.
        /// </summary>
        /// <param name="message">The message to be shown.</param>
        /// <param name="action">The text for the action button of the snackbar.</param>
        /// <param name="callback">The callback method for when the action button is pressed.</param>
        void ShowShortSnackbar(string message, string action = null, Action<object> callback = null);

        /// <summary>
        ///     Shows a snackbar on screen for a long period of time to give the user a message and allow them to act towards it.
        /// </summary>
        /// <param name="message">The message to be shown.</param>
        /// <param name="action">The text for the action button of the snackbar.</param>
        /// <param name="callback">The callback method for when the action button is pressed.</param>
        void ShowLongSnackbar(string message, string action = null, Action<object> callback = null);
    }
}