[assembly: Xamarin.Forms.ResolutionGroupName("FlowChart")]
[assembly: Xamarin.Forms.ExportEffect(typeof(FlowChart.Droid.Effects.RoundCornersEffectDroid), nameof(FlowChart.Effects.RoundCornersEffect))]
namespace FlowChart.Droid.Effects
{
    using Android.Graphics;
    using Android.Views;
    using FlowChart.Effects;
    using System;
    using System.Linq;
    using Xamarin.Essentials;
    using Xamarin.Forms.Platform.Android;
    using Debug = System.Diagnostics.Debug;

    /// <summary>
    ///     The Android implementation of <see cref="RoundCornersEffect" />.
    /// </summary>
    public class RoundCornersEffectDroid : PlatformEffect
    {
        private RoundCornersEffect effect;
        
        private View View => Control ?? Container;

        /// <summary>
        ///    Method that is called after the effect is attached and made valid. 
        /// </summary>
        protected override void OnAttached()
        {
            try
            {
                effect = (RoundCornersEffect)Element.Effects.FirstOrDefault(e => e is RoundCornersEffect);
                if (effect == null)
                    return;

                View.ClipToOutline = true;
                View.OutlineProvider = new RoundedOutlineProvider(effect.CornerRadius * GetDensity());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        /// <summary>
        ///    Method that is called after the effect is detached and invalidated.
        /// </summary>
        protected override void OnDetached()
        {
            try
            {
                View.OutlineProvider = ViewOutlineProvider.Background;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private double GetDensity() => DeviceDisplay.MainDisplayInfo.Density;

        private class RoundedOutlineProvider : ViewOutlineProvider
        {
            private readonly double radius;

            public RoundedOutlineProvider(double radius)
            {
                this.radius = radius;
            }

            public override void GetOutline(View view, Outline outline)
            {
                outline?.SetRoundRect(0, 0, view.Width, view.Height, (float)radius);
            }
        }
    }
}