namespace CatenarySupport.Providers.DTO
{
    public class ProtocolData : IDataObject
    {
        public string UUID { get; set; }

        public string? Plant { get; set; }

        public string? District { get; set; }

        public int? ProtocolID { get; set; }

        public string? ProtocolDate { get; set; }

        public string? Foreman { get; set; }

        public string? Notes { get; set; }
    }
}
