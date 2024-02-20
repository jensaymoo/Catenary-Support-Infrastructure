using LinqToDB.Mapping;
using System.ComponentModel;

namespace CatenarySupport.Database.Tables
{
    [Table("стойки")]
    public class MastTypeTable
    {
        [Column("masttype_uuid"), PrimaryKey, NotNull, DataType("TEXT")]
        public string? UUID { get; set; }

        [Column("тип_стк"), DataType("TEXT")]
        public string? MastType { get; set; }

        [Column("мат_стк"), DataType("TEXT")]
        public string? MastMaterial { get; set; }

    }
}
