using LinqToDB.Mapping;
using System.ComponentModel;

namespace CatenarySupport.Database.Tables
{
    [Table("стойки")]
    public class MastTypeTable
    {
        [Column("тип_стк"), DataType("TEXT")]
        public string? MastType { get; set; }

        [Column("мат_стк"), DataType("TEXT")]
        public string? MastMaterial { get; set; }

    }
}
