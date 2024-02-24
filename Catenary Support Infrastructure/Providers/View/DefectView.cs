using CatenarySupport.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CatenarySupport.Providers.View
{
    public class DefectView : IViewObject
    {
        [Display(AutoGenerateField = false), ReadOnly(true)]
        public required string UUID { get; set; }

        [Display(AutoGenerateField = false), ReadOnly(true)]
        public required string MastUUID { get; set; }

        [Display(AutoGenerateField = false), ReadOnly(true)]
        public required string ProtocolUUID { get; set; }

        [Display(AutoGenerateField = true, Name = "Протокол"), NotNull]
        public int? ProtocolID { get; set; }

        [Display(AutoGenerateField = true, Name = "Дата"), NotNull]
        public string? ProtocolDate { get; set; }

        [Display(AutoGenerateField = true, Name = "Дефект"), NotNull]
        public string? Defect { get; set; }

        [Display(AutoGenerateField = true, Name = "Описание"), MultilineTextColumn]
        public string? Description { get; set; }

        [Display(AutoGenerateField = true, Name = "Фото"), ImageColumn]
        public byte[]? Photo { get; set; }
    }
}
