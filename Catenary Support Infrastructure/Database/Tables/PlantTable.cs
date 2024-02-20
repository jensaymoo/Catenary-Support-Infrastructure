using LinqToDB.Mapping;
using System.ComponentModel;

namespace CatenarySupport.Database.Tables
{
    [Table("цеха")]
    public class PlantTable
    {
        [Column("plant_uuid"), PrimaryKey, NotNull, DataType("TEXT")]
        public string? UUID { get; set; }

        [Column("цех"), DisplayName("Цех"), DataType("TEXT")]
        public string? Plant { get; set; }

        [Column("дислокация"), DisplayName("Дислокация"), DataType("TEXT")]
        public string? PlantDislocation { get; set; }
    }
}
