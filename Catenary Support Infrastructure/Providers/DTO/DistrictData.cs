namespace CatenarySupport.Providers.DTO
{
    public class DistrictData: IDataObject
    {
        public string? UUID { get; set; }

        public string? District { get; set; }

        public string? SoilCharacteristics { get; set; }

        public int? MaxSpeed { get; set; }
    }
}
