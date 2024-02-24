using LinqToDB.Mapping;

namespace CatenarySupport.Providers.Data
{
    public class MeasurmentData
    {
        public required string UUID { get; set; }

        public required string MastUUID { get; set; }

        public required string ProtocolUUID { get; set; }

        public float? MeasurmentR { get; set; }

        public float? MeasurmentU1 { get; set; }

        public float? MeasurmentU2 { get; set; }

        public float? MeasurmentP1 { get; set; }

        public float? MeasurmentP2 { get; set; }

        public float? FoundationS { get; set; }

        public float? AnchorS { get; set; }

        public string? AnalysisType { get; set; }

        public float? TiltAlong{ get; set; }

        public float? TiltAcross { get; set; }

        public string? MastDefect { get; set; }

        public string? FoundationDefect { get; set; }

        public string? AnchorDefect { get; set; }
    }
}
