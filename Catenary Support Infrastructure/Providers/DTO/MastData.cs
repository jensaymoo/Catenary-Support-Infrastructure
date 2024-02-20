namespace CatenarySupport.Providers.DTO
{
    public class MastData : IDataObject
    {
        public string UUID { get; set; }

        public string? Plant { get; set; }

        public string? District { get; set; }

        public string? Track { get; set; }

        public int? MastID { get; set; }

        public string? MastLiter { get; set; }

        public string? MastType { get; set; }

        public int? MastCount { get; set; }

        public string? FoundationType { get; set; }

        public int? FoundationCount{ get; set; }

        public string? AnchorType { get; set; }

        public int? AnchorCount { get; set; }

        public string? Notes { get; set; }

    }
}
