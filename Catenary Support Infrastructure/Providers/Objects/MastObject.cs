using CatenarySupport.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace CatenarySupport.Providers.Objects
{
    public class MastObject
    {
        [Display(AutoGenerateField = false, Name = "mast_uuid"), ReadOnly(true)]
        public string UUID { get; set; }

        [Display(AutoGenerateField = true, Name = "Цех"), BindedGridColumn(typeof(PlantObject))]
        public string? Plant { get; set; }

        [Display(AutoGenerateField = true, Name = "Участок"), BindedGridColumn(typeof(DistrictObject))]
        public string? District { get; set; }

        [Display(AutoGenerateField = true, Name = "Путь")]
        public string? Track { get; set; }

        [Display(AutoGenerateField = true, Name = "Опора")]
        public int? MastID { get; set; }

        [Display(AutoGenerateField = true, Name = "Индекс")]
        public string? MastLiter { get; set; }

        [Display(AutoGenerateField = true, Name = "Тип стойки"), BindedGridColumn(typeof(MastTypeObject))]
        public string? MastType { get; set; }

        [Display(AutoGenerateField = true, Name = "Кол-во стоек"), SpinColumn]
        public int? MastCount { get; set; }

        [Display(AutoGenerateField = true, Name = "Тип фундамента")]
        public string? FoundationType { get; set; }

        [Display(AutoGenerateField = true, Name = "Кол-во фундаментов"), SpinColumn]
        public int? FoundationCount{ get; set; }

        [Display(AutoGenerateField = true, Name = "Тип анкера")]
        public string? AnchorType { get; set; }

        [Display(AutoGenerateField = true, Name = "Кол-во анкеров"), SpinColumn]
        public int? AnchorCount { get; set; }

        [Display(AutoGenerateField = true, Name = "Примечания"), MultilineTextColumn]
        public string? Notes { get; set; }

    }
}
