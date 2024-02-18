using CatenarySupport.Attributes;
using System.ComponentModel;

namespace CatenarySupport.Providers.Objects
{
    public class ProtocolObject
    {
        [DisplayName("protocol_uuid")]
        public string UUID { get; set; }

        [DisplayName("Цех"), BindedGridColumn(typeof(PlantObject))]
        public string? Plant { get; set; }

        [DisplayName("Участок"), BindedGridColumn(typeof(DistrictObject))]
        public string? District { get; set; }

        [DisplayName("Протокол"), ReadOnly(true)]
        public int ProtocolID { get; set; }

        [DisplayName("Дата")]
        public string? ProtocolDate { get; set; }

        [DisplayName("Производитель")]
        public string? Foreman { get; set; }

        [DisplayName("Примечания"), MultilineTextColumn]
        public string? Notes { get; set; }
    }
}
