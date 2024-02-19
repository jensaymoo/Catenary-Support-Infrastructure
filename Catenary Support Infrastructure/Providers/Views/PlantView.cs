using System.ComponentModel.DataAnnotations;

namespace CatenarySupport.Providers.Views
{
    public class PlantView : IViewObject
    {
        [Display(AutoGenerateField = true, Name = "Цех")]
        public string? Plant { get; set; }

        [Display(AutoGenerateField = true, Name = "Дислокация")]
        public string? PlantDislocation { get; set; }
    }
}
