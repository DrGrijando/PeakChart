using SQLite;

namespace FlowChart.Database.Models
{
    [Table("ReadingMonths")]
    public class ReadingMonth
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("month")]
        public int Month { get; set; }

        [Column("year")]
        public int Year { get; set; }

        [Column("readingCount")]
        public int ReadingCount { get; set; }
    }
}
