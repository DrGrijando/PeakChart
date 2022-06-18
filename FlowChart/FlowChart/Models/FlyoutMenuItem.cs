namespace FlowChart.Models
{
    using System;

    public class FlyoutMenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Type TargetType { get; set; }

        public FlyoutMenuItem()
        {
            TargetType = typeof(FlyoutMenuItem);
        }
    }
}