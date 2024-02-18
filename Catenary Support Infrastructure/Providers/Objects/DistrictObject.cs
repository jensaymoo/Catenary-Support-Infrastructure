using LinqToDB.Mapping;
using System.ComponentModel;

namespace CatenarySupport.Providers.Objects
{
    public class DistrictObject
    {
        [DisplayName("Участок")]
        public string? District { get; set; }

        [DisplayName("Грунт"),]
        public string? SoilCharacteristics { get; set; }

        [DisplayName("Установленная скорость")]
        public int? MaxSpeed { get; set; }
    }
}
