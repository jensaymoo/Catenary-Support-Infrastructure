using CatenarySupport.Attributes;
using CatenarySupport.Database.Tables;
using LinqToDB.Mapping;
using System.ComponentModel;

namespace CatenarySupport.Database.Tables
{
    [Table("protocols")]
    public class ProtocolTable
    {
        [Column("protocol_uuid"), PrimaryKey, DataType("TEXT")]
        public string UUID { get; set; }

        [Column("plant"), DataType("TEXT")]
        public string? Plant { get; set; }

        [Column("district"), DataType("TEXT")]
        public string? District { get; set; }

        [Column("protocol_id"), DataType("INTEGER")]
        public int ProtocolID { get; set; }

        [Column("protocol_date"), DataType("TEXT")]
        public string? ProtocolDate { get; set; }

        [DisplayName("foreman"), DataType("TEXT")]
        public string? Foreman { get; set; }

        [DisplayName("notes"), , DataType("TEXT")]
        public string? Notes { get; set; }
    }
}
