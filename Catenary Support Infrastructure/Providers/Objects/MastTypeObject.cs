using System.ComponentModel;


namespace CatenarySupport.Providers
{
    public class MastTypeObject
    {
        [DisplayName("Тип стойки")]
        public string? MastType { get; set; }

        [DisplayName("Материал")]
        public string? MastMaterial { get; set; }
    }
}
