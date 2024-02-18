using System.ComponentModel.DataAnnotations;

namespace CatenarySupport.Providers.Objects
{
    public class DistrictObject
    {
        [Display(AutoGenerateField = true, Name = "Участок")]
        public string? District { get; set; }

        [Display(AutoGenerateField = true, Name = "Грунт"),]
        public string? SoilCharacteristics { get; set; }

        [Display(AutoGenerateField = true, Name = "Установленная скорость")]
        public int? MaxSpeed { get; set; }
    }
}
