using CatenarySupport.Attributes;
using CatenarySupport.Database.Tables;
using System.ComponentModel;


namespace CatenarySupport.Providers.Objects
{
    public class MastObject
    {
        [DisplayName("mast_uuid"), ReadOnly(true)]
        public string UUID { get; set; }

        [DisplayName("Цех"), BindedGridColumn(typeof(PlantObject))]
        public string? Plant { get; set; }

        [DisplayName("Участок"), BindedGridColumn(typeof(DistrictObject))]
        public string? District { get; set; }

        [DisplayName("Путь")]
        public string? Track { get; set; }

        [DisplayName("Опора")]
        public int? MastID { get; set; }

        [DisplayName("Индекс")]
        public string? MastLiter { get; set; }

        [DisplayName("Тип стойки"), BindedGridColumn(typeof(MastTypeObject))]
        public string? MastType { get; set; }

        [DisplayName("Кол-во стоек"), SpinColumn]
        public int? MastCount { get; set; }

        [DisplayName("Тип фундамента")]
        public string? FoundationType { get; set; }

        [DisplayName("Кол-во фундаментов"), SpinColumn]
        public int? FoundationCount{ get; set; }

        [DisplayName("Тип анкера")]
        public string? AnchorType { get; set; }

        [DisplayName("Кол-во анкеров"), SpinColumn]
        public int? AnchorCount { get; set; }

        [DisplayName("Примечания"), MultilineTextColumn]
        public string? Notes { get; set; }

    }
}
