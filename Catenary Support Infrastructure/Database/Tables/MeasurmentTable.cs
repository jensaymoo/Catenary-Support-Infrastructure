using CatenarySupport.Attributes;
using CatenarySupport.Database.Tables;
using LinqToDB.Mapping;
using System.ComponentModel;

namespace CatenarySupport.Database.Tables
{
    [Table("measurments")]
    public class MeasurmentTable
    {
        [Column("measurment_uuid"), PrimaryKey, DataType("TEXT")]
        public required string UUID { get; set; }

        [Column("mast_uuid"), DataType("TEXT")]
        public required string MastUUID { get; set; }

        [Column("protocol_uuid"), DataType("TEXT")]
        public required string ProtocolUUID { get; set; }

        [Column("measurment_r"), DataType("REAL")]
        public float? MeasurmentR { get; set; }

        [Column("measurment_u1"), DataType("REAL")]
        public float? MeasurmentU1 { get; set; }

        [Column("measurment_u2"), DataType("REAL")]
        public float? MeasurmentU2 { get; set; }

        [Column("measurment_p1"), DataType("REAL")]
        public float? MeasurmentP1 { get; set; }

        [Column("measurment_p2"), DataType("REAL")]
        public float? MeasurmentP2 { get; set; }

        [Column("measurment_foundation_s"), DataType("REAL")]
        public float? FoundationS { get; set; }

        [Column("measurment_anchor_s"), DataType("REAL")]
        public float? AnchorS { get; set; }

        [Column("analysis_type"), DataType("TEXT")]
        public string? AnalysisType { get; set; }

        [Column("tilt_along"), DataType("REAL")]
        public float? TiltAlong{ get; set; }

        [Column("titl_across"), DataType("REAL")]
        public float? TiltAcross { get; set; }

        [Column("mast_defect"), DataType("REAL")]
        public string? MastDefect { get; set; }

        [Column("foundation_defect"), DataType("REAL")]
        public string? FoundationDefect { get; set; }

        [Column("anchor_defect"), DataType("REAL")]
        public string? AnchorDefect { get; set; }
    }
}
