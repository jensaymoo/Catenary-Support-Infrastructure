
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenarySupport.Database.Tables
{
    [Table("pillars")]
    public class PillarData
    {
        [Column("pillar_uuid"), PrimaryKey]
        public Guid PillarUUID { get; set; }

        [Column("plant")]
        public string? Plant {  get; set; }

        [Column("district")]
        public string? District { get; set; }

        [Column("track")]
        public string? Track { get; set; }

        [Column("pillar")]
        public string? Pillar { get; set; }

        [Column("liter")]
        public string? Liter { get; set; }

        [Column("material")]
        public string? Material { get; set; }
    }
}
