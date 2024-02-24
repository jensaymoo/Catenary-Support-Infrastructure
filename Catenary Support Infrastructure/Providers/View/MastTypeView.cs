using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CatenarySupport.Providers.View
{
    public class MastTypeView : IViewObject
    {
        [Display(AutoGenerateField = false), ReadOnly(true)]
        public string? UUID { get; set; }

        [Display(AutoGenerateField = true, Name = "Тип стойки")]
        public string? MastType { get; set; }

        [Display(AutoGenerateField = true, Name = "Материал")]
        public string? MastMaterial { get; set; }
    }
}
