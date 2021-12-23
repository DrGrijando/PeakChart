using System;

namespace FlowChart.Models
{
    public class FlowReading
    {
        public float Value { get; set; }

        public DateTime Date { get; set; }

        public bool IsNightPeriod { get; set; }
    }
}
