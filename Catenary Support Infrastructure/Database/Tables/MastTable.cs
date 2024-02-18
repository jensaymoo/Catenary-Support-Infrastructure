using CatenarySupport.Attributes;
using LinqToDB.Mapping;
using System.ComponentModel;


namespace CatenarySupport.Database.Tables
{
    [Table("masts")]
    public class MastTable
    {
        [Column("mast_uuid"), PrimaryKey, DataType("TEXT")]
        public string UUID { get; set; }

        [Column("plant"), DataType("TEXT")]
        public string? Plant { get; set; }

        [Column("district"), DataType("TEXT")]
        public string? District { get; set; }

        [Column("track"), DataType("TEXT")]
        public string? Track { get; set; }

        [Column("mast_id"), DataType("INTEGER")]
        public int? MastID { get; set; }

        [Column("mast_liter"), DataType("TEXT")]
        public string? MastLiter { get; set; }

        [Column("mast_type"), DataType("TEXT")]
        public string? MastType { get; set; }

        [Column("mast_count"), DataType("INTEGER")]
        public int? MastCount { get; set; }

        [Column("foundation_type"), DataType("TEXT")]
        public string? FoundationType { get; set; }

        [Column("foundation_count"), DataType("INTEGER")]
        public int? FoundationCount{ get; set; }

        [Column("anchor_type"), DataType("TEXT")]
        public string? AnchorType { get; set; }

        [Column("anchor_count"), DataType("INTEGER")]
        public int? AnchorCount { get; set; }

        [Column("Примечания"), DataType("TEXT")]
        public string? Notes { get; set; }

    }
}
