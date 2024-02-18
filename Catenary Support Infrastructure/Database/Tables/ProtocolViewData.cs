using CatenarySupport.Attributes;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenarySupport.Database.Tables
{
    public class ProtocolViewData
    {
        [DisplayName("protocol_uuid")]
        public string UUID { get; set; }

        [DisplayName("Цех"), BindedGridColumn(typeof(PlantObject))]
        public string? Plant { get; set; }

        [DisplayName("Участок"), BindedGridColumn(typeof(DistrictTable))]
        public string? District { get; set; }

        [DisplayName("Протокол"), ReadOnly(true), BindedGridColumn(typeof(DistrictTable))]
        public int ProtocolID { get; set; }

        [DisplayName("Дата"), ReadOnly(true), BindedGridColumn(typeof(DistrictTable))]
        public string? ProtocolDate { get; set; }

        [DisplayName("Производитель"), BindedGridColumn(typeof(DistrictTable))]
        public string? Foreman { get; set; }

        [Column("Примечания"), DisplayName("Примечания"), DataType("TEXT"), MultilineTextColumn]
        public string? Notes { get; set; }

    }
}
