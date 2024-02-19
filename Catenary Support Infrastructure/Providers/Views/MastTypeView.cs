using System.ComponentModel.DataAnnotations;

namespace CatenarySupport.Providers.Views
{
    public class MastTypeView : IViewObject
    {
        [Display(AutoGenerateField = true, Name = "Тип стойки")]
        public string? MastType { get; set; }

        [Display(AutoGenerateField = true, Name = "Материал")]
        public string? MastMaterial { get; set; }
    }
}
