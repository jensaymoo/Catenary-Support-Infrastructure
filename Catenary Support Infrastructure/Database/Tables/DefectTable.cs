using LinqToDB.Mapping;
using System.ComponentModel;

namespace CatenarySupport.Database.Tables
{
    [Table("defects")]
    public class DefectTable
    {
        [Column("defect_uuid"), PrimaryKey, NotNull, DataType("TEXT")]
        public string? UUID { get; set; }

        [Column("measurment_uuid"), NotNull, DataType("TEXT")]
        public string? MeasurmentUUID { get; set; }

        [Column("defect"), DataType("TEXT")]
        public string? Defect { get; set; }

        [Column("description"), DataType("TEXT")]
        public string? Description { get; set; }

        [Column("photo"), DataType("BLOB")]
        public byte[]? Photo { get; set; }
    }
}
