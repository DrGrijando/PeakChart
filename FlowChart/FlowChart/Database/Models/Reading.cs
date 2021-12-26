using SQLite;
using System;

namespace FlowChart.Database.Models
{
    [Table("readings")]
    public class Reading
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("value")]
        public int Value { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Indexed]
        [Column("monthId")]
        public int MonthId { get; set; }

        [Column("isNightPeriod")]
        public bool IsNightPeriod { get; set; }

        [Column("note")]
        public string Note { get; set; }
    }
}
