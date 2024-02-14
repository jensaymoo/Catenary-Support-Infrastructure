using LinqToDB.Mapping;
using System.ComponentModel;

namespace CatenarySupport.Database.Tables
{
    [Table("стойки")]
    public class MastTypeData
    {
        [Column("тип_стк"), DisplayName("Тип стойки"), DataType("TEXT")]
        public string? MastType { get; set; }

        [Column("мат_стк"), DisplayName("Материал"), DataType("TEXT")]
        public string? MastMaterial { get; set; }

    }
}
