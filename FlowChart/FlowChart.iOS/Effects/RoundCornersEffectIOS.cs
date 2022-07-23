[assembly: Xamarin.Forms.ResolutionGroupName("FlowChart")]
[assembly: Xamarin.Forms.ExportEffect(typeof(FlowChart.iOS.Effects.RoundCornersEffectIOS), nameof(FlowChart.Effects.RoundCornersEffect))]
namespace FlowChart.iOS.Effects
{
    using System;
    using FlowChart.Effects;
    using Xamarin.Forms.Platform.iOS;
    using System.Diagnostics;
    using CoreAnimation;
    using System.Linq;

    /// <summary>
    ///     The iOS implementation of <see cref="RoundCornersEffect" />.
    /// </summary>
    public class RoundCornersEffectIOS : PlatformEffect
    {
        private RoundCornersEffect effect;

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

                Container.ClipsToBounds = true;
                Container.Layer.AllowsEdgeAntialiasing = true;
                Container.Layer.EdgeAntialiasingMask = CAEdgeAntialiasingMask.All;
                Container.Layer.CornerRadius = new nfloat(effect.CornerRadius);
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
                Container.Layer.CornerRadius = new nfloat(0);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}