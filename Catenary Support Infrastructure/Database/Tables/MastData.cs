using CatenarySupport.Attributes;
using LinqToDB.Mapping;
using System.ComponentModel;

namespace CatenarySupport.Database.Tables
{
    [Table("masts")]
    public class MastData
    {
        [Column("mast_uuid"), PrimaryKey, Identity, NotNull, DataType("INTEGER")]
        public int UUID { get; set; }

        [Column("plant"), DisplayName("Цех"), DataType("TEXT"), BindedGridColumn(typeof(PlantData))]
        public string? Plant { get; set; }

        [Column("district"), DisplayName("Участок"), DataType("TEXT"), BindedGridColumn(typeof(DistrictData))]
        public string? District { get; set; }

        [Column("track"), DisplayName("Путь"), DataType("TEXT")]
        public string? Track { get; set; }

        [Column("mast_id"), DisplayName("Опора"), DataType("INTEGER")]
        public int? MastID { get; set; }

        [Column("mast_liter"), DisplayName("Индекс"), DataType("TEXT")]
        public string? MastLiter { get; set; }

        [Column("mast_type"), DisplayName("Тип стойки"), DataType("TEXT"), BindedGridColumn(typeof(MastTypeData))]
        public string? MastType { get; set; }

        [Column("mast_count"), DisplayName("Кол-во стоек"), DataType("INTEGER"), SpinColumn]
        public int? MastCount { get; set; }

        [Column("foundation_type"), DisplayName("Тип фундамента"), DataType("TEXT")]
        public string? FoundationType { get; set; }

        [Column("foundation_count"), DisplayName("Кол-во фундаментов"), DataType("INTEGER"), SpinColumn]
        public int? FoundationCount{ get; set; }

        [Column("anchor_type"), DisplayName("Тип анкера"), DataType("TEXT")]
        public string? AnchorType { get; set; }

        [Column("anchor_count"), DisplayName("Кол-во анкеров"), DataType("INTEGER"), SpinColumn]
        public int? AnchorCount { get; set; }

        [Column("Примечания"), DisplayName("Примечания"), DataType("TEXT"), MultilineTextColumn]
        public string? Notes { get; set; }

    }
}
