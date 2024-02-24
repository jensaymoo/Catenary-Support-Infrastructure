namespace CatenarySupport.Providers.Data
{
    public class MeasurmentData
    {
        public string? UUID { get; set; }

        public string? MastUUID { get; set; }

        public string? ProtocolUUID { get; set; }

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
    }
}
