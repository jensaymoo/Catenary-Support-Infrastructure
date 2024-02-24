using CatenarySupport.Attributes;
using FluentValidation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CatenarySupport.Providers.View
{
    public class ProtocolSmallView : IViewObject
    {
        [Display(AutoGenerateField = false), ReadOnly(true)]
        public string? UUID { get; set; }


        [Display(AutoGenerateField = true, Name = "Протокол"), NotNull, ReadOnly(true)]
        public int? ProtocolID { get; set; }

        [Display(AutoGenerateField = true, Name = "Дата"), NotNull, DateColumn]
        public string? ProtocolDate { get; set; }

        [Display(AutoGenerateField = true, Name = "Производитель"), NotNull]
        public string? Foreman { get; set; }

        [Display(AutoGenerateField = true, Name = "Вид обследования")]
        public string? AnalysisType { get; set; }

        [Display(AutoGenerateField = true, Name = "Измеренные праметры")]
        public string? MeasurmentParamerters { get; set; }

        [Display(AutoGenerateField = true, Name = "Примечания"), NotNull, MultilineTextColumn]
        public string? Notes { get; set; }
    }
}
