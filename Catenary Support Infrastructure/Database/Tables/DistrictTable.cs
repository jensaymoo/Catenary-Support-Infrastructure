using LinqToDB.Mapping;
using System.ComponentModel;

namespace CatenarySupport.Database.Tables
{
    [Table("участки")]
    public class DistrictTable
    {
        [Column("district_uuid"), PrimaryKey, NotNull, DataType("TEXT")]
        public string? UUID { get; set; }

        [Column("участок"), DisplayName("Участок"), DataType("TEXT")]
        public string? District { get; set; }

        [Column("характеристика_грунта"), DisplayName("Грунт"), DataType("TEXT")]
        public string? SoilCharacteristics { get; set; }

        [Column("уст_скорость"), DisplayName("Установленная скорость"), DataType("INTEGER")]
        public int? MaxSpeed { get; set; }
    }
}
