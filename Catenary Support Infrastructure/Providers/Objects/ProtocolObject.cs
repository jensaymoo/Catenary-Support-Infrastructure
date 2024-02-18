using CatenarySupport.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CatenarySupport.Providers.Objects
{
    public class ProtocolObject
    {
        [Display(AutoGenerateField = false, Name = "UUID Protocol")]
        public string UUID { get; set; }

        [Display(AutoGenerateField = true, Name = "Цех"), BindedGridColumn(typeof(PlantObject))]
        public string? Plant { get; set; }

        [Display(AutoGenerateField = true, Name = "Участок"), BindedGridColumn(typeof(DistrictObject))]
        public string? District { get; set; }

        [Display(AutoGenerateField = true, Name = "Протокол"), ReadOnly(true)]
        public int ProtocolID { get; set; }

        [Display(AutoGenerateField = true, Name = "Дата")]
        public string? ProtocolDate { get; set; }

        [Display(AutoGenerateField = true, Name = "Производитель")]
        public string? Foreman { get; set; }

        [Display(AutoGenerateField = true, Name = "Примечания"), MultilineTextColumn]
        public string? Notes { get; set; }
    }
}
