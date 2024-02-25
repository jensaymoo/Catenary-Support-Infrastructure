namespace CatenarySupport.Providers.Data
{
    public class ProtocolData : IDataObject
    {
        public string? UUID { get; set; }

        public string? PlantUUID { get; set; }

        public string? DistrictUUID { get; set; }

        public int? ProtocolID { get; set; }

        public string? ProtocolDate { get; set; }

        public string? Foreman { get; set; }

        public string? Notes { get; set; }
    }
}
