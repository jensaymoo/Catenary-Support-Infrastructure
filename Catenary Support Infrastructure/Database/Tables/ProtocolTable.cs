using LinqToDB.Mapping;

namespace CatenarySupport.Database.Tables
{
    [Table("protocols")]
    public class ProtocolTable
    {
        [Column("protocol_uuid"), PrimaryKey, NotNull, DataType("TEXT")]
        public string? UUID { get; set; }

        [Column("plant_uuid"), NotNull, DataType("TEXT")]
        public string? PlantUUID { get; set; }

        [Column("district_uuid"), NotNull, DataType("TEXT")]
        public string? DistrictUUID { get; set; }

        [Column("protocol_id"), NotNull, DataType("INTEGER")]
        public int ProtocolID { get; set; }

        [Column("protocol_date"), NotNull, DataType("DATE")]
        public string? ProtocolDate { get; set; }

        [Column("foreman"), NotNull, DataType("TEXT")]
        public string? Foreman { get; set; }

        [Column("notes"), DataType("TEXT")]
        public string? Notes { get; set; }
    }
}
