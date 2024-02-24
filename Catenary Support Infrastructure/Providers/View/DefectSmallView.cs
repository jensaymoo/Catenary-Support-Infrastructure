using CatenarySupport.Attributes;
using FluentValidation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CatenarySupport.Providers.View
{
    public class DefectSmallView : IViewObject
    {
        [Display(AutoGenerateField = false), ReadOnly(true)]
        public required string UUID { get; set; }

        [Display(AutoGenerateField = false), ReadOnly(true)]
        public required string MastUUID { get; set; }

        [Display(AutoGenerateField = false), ReadOnly(true)]
        public required string ProtocolUUID { get; set; }

        [Display(AutoGenerateField = true, Name = "Дефект"), NotNull]
        public string? Defect { get; set; }

        [Display(AutoGenerateField = true, Name = "Описание"), MultilineTextColumn]
        public string? Descriptions { get; set; }

        [Display(AutoGenerateField = true, Name = "Фото"), ImageColumn]
        public string? Photo { get; set; }
    }
}
