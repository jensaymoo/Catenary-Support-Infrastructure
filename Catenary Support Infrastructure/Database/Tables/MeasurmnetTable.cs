using CatenarySupport.Attributes;
using CatenarySupport.Database.Tables;
using LinqToDB.Mapping;
using System.ComponentModel;

namespace CatenarySupport.Database.Tables
{
    [Table("measurments")]
    public class MeasurmentTable
    {
        [Column("measurment_uuid"), PrimaryKey, DataType("TEXT")]
        public string UUID { get; set; }

        [Column("mast_uuid"), DataType("TEXT")]
        public string MastUUID { get; set; }

        [Column("protocol_uuid"), DataType("TEXT")]
        public string ProtocolUUID { get; set; }


    }
}
