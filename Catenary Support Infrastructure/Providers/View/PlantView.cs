using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CatenarySupport.Providers.View
{
    public class PlantView : IViewObject
    {
        [Display(AutoGenerateField = false), ReadOnly(true)]
        public string? UUID { get; set; }

        [Display(AutoGenerateField = true, Name = "Цех")]
        public string? Plant { get; set; }

        [Display(AutoGenerateField = true, Name = "Дислокация")]
        public string? PlantDislocation { get; set; }
    }
}
