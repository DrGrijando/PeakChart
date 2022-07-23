namespace FlowChart.Effects
{
    using Xamarin.Forms;

    /// <summary>
    ///     An effect to apply round corners to any View.
    /// </summary>
    public class RoundCornersEffect : RoutingEffect
    {
        /// <summary>
        ///     Creates a new instance of the <see cref="RoundCornersEffect"/>.
        /// </summary>
        public RoundCornersEffect() : base($"FlowChart.{nameof(RoundCornersEffect)}") { }

        /// <summary>
        ///     The corner radius of the view. The same value will be applied to all corners.
        /// </summary>
        public int CornerRadius { get; set; }
    }
}
