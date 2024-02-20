using CatenarySupport.Attributes;
using FluentValidation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace CatenarySupport.Providers.Views
{
    public class MastView : IViewObject
    {
        [Display(AutoGenerateField = false), ReadOnly(true)]
        public string? UUID { get; set; }

        [Display(AutoGenerateField = true, Name = "Цех"), BindedGridColumn(typeof(PlantView))]
        public string? Plant { get; set; }

        [Display(AutoGenerateField = true, Name = "Участок"), BindedGridColumn(typeof(DistrictView))]
        public string? District { get; set; }

        [Display(AutoGenerateField = true, Name = "Путь")]
        public string? Track { get; set; }

        [Display(AutoGenerateField = true, Name = "Опора")]
        public int? MastID { get; set; }

        [Display(AutoGenerateField = true, Name = "Индекс")]
        public string? MastLiter { get; set; }

        [Display(AutoGenerateField = true, Name = "Тип стойки"), BindedGridColumn(typeof(MastTypeView))]
        public string? MastType { get; set; }

        [Display(AutoGenerateField = true, Name = "Кол-во стоек"), SpinColumn]
        public int? MastCount { get; set; }

        [Display(AutoGenerateField = true, Name = "Тип фундамента")]
        public string? FoundationType { get; set; }

        [Display(AutoGenerateField = true, Name = "Кол-во фундаментов"), SpinColumn]
        public int? FoundationCount{ get; set; }

        [Display(AutoGenerateField = true, Name = "Тип анкера")]
        public string? AnchorType { get; set; }

        [Display(AutoGenerateField = true, Name = "Кол-во анкеров"), SpinColumn]
        public int? AnchorCount { get; set; }

        [Display(AutoGenerateField = true, Name = "Примечания"), MultilineTextColumn]
        public string? Notes { get; set; }

    }
    internal class MastViewValidator : AbstractValidator<MastView>
    {
        public MastViewValidator()
        {
            RuleFor(opt => opt.UUID)
                .NotEmpty().WithMessage("должно быть заполнено");

            RuleFor(opt => opt.Plant)
                .NotEmpty().WithMessage("должно быть заполнено");

            RuleFor(opt => opt.District)
                .NotEmpty().WithMessage("должно быть заполнено");

            RuleFor(opt => opt.MastID)
                .NotEmpty().WithMessage("должно быть заполнено");

            RuleFor(opt => opt.MastType)
                .NotEmpty().WithMessage("должно быть заполнено");

            RuleFor(opt => opt.MastCount)
                .NotEmpty().WithMessage("должно быть заполнено")
                .GreaterThan(0).WithMessage("должно быть больше '0'");

            RuleFor(opt => opt)
                .Custom((obj, context) =>
                {
                    if ((obj.FoundationType != null && obj.FoundationType != string.Empty) && obj.FoundationCount != obj.MastCount)
                        context.AddFailure("FoundationCount", "количество фундаментов не равно количеству стоек");

                    if (obj.FoundationCount != 0 && (obj.FoundationType == null || obj.FoundationType == string.Empty))
                        context.AddFailure("FoundationCount", "не равно '0', при этом тип фундамента не указан");
                });

            RuleFor(opt => opt)
                .Custom((obj, context) =>
                {
                    if ((obj.AnchorCount != null && obj.AnchorCount != 0) && (obj.AnchorType == null || obj.AnchorType == string.Empty))
                        context.AddFailure("AnchorCount", "не равно '0', при этом тип анкера не указан");
                });
        }
    }
}
