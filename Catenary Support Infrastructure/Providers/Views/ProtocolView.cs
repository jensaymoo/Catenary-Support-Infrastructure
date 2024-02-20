using CatenarySupport.Attributes;
using FluentValidation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CatenarySupport.Providers.Views
{
    public class ProtocolView : IViewObject
    {
        [Display(AutoGenerateField = false), ReadOnly(true)]
        public string? UUID { get; set; }

        [Display(AutoGenerateField = true, Name = "Цех"), NotNull, BindedGridColumn(typeof(PlantView))]
        public string? Plant { get; set; }

        [Display(AutoGenerateField = true, Name = "Участок"), NotNull, BindedGridColumn(typeof(DistrictView))]
        public string? District { get; set; }

        [Display(AutoGenerateField = true, Name = "Протокол"), NotNull, ReadOnly(true)]
        public int? ProtocolID { get; set; }

        [Display(AutoGenerateField = true, Name = "Дата"), NotNull, DateColumn]
        public string? ProtocolDate { get; set; }

        [Display(AutoGenerateField = true, Name = "Производитель"), NotNull]
        public string? Foreman { get; set; }

        [Display(AutoGenerateField = true, Name = "Примечания"), NotNull, MultilineTextColumn]
        public string? Notes { get; set; }
    }
    internal class ProtocolViewValidator : AbstractValidator<ProtocolView>
    {
        public ProtocolViewValidator()
        {
            RuleFor(opt => opt.UUID)
                .NotEmpty().WithMessage("должно быть заполнено");
            
            RuleFor(opt => opt.Plant)
                .NotEmpty().WithMessage("должно быть заполнено");

            RuleFor(opt => opt.District)
                .NotEmpty().WithMessage("должно быть заполнено");

            RuleFor(opt => opt.ProtocolDate)
                .NotEmpty().WithMessage("должно быть заполнено");

            RuleFor(opt => opt.Foreman)
                .NotEmpty().WithMessage("должно быть заполнено");
        }
    }
}
