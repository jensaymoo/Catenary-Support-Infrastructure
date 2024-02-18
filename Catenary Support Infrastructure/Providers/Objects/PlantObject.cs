using LinqToDB.Mapping;
using System.ComponentModel;

namespace CatenarySupport.Database.Tables
{
    public class PlantObject
    {
        [ DisplayName("Цех")]
        public string? Plant { get; set; }

        [DisplayName("Дислокация")]
        public string? PlantDislocation { get; set; }
    }
}
