namespace CatenarySupport.Providers.Data
{
    public class DefectData: IDataObject
    {
        public string UUID { get; set; }

        public string? MastUUID { get; set; }

        public string? ProtocolUUID { get; set; }

        public string? Defect { get; set; }
        
        public string? Description { get; set;}
        
        public byte[]? Photo { get; set; }
    }
}
