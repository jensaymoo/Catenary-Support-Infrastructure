using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CatenarySupport.Attributes;

namespace CatenarySupport.Providers.View
{
    public class MeasurmentView : IViewObject
    {
        [Display(AutoGenerateField = false), ReadOnly(true)]
        public required string UUID { get; set; }

        [Display(AutoGenerateField = false)]
        public required string MastUUID { get; set; }

        [Display(AutoGenerateField = false)]
        public required string ProtocolUUID { get; set; }

        [Display(AutoGenerateField = true, Name = "Цех"), ReadOnly(true)]
        public string? Plant { get; set; }

        [Display(AutoGenerateField = true, Name = "Участок"), ReadOnly(true)]
        public string? District { get; set; }

        [Display(AutoGenerateField = true, Name = "Опора"), BindedGridColumn(typeof(MastView))]
        public required string MastID { get; set; }

        [Display(AutoGenerateField = true, Name = "Протокол")]
        public required string Protocol { get; set; }

        [Display(AutoGenerateField = true, Name = "Изм. R")]
        public bool MeasurmentEnableR { get; set; }

        [Display(AutoGenerateField = true, Name = "R, Ом")]
        public float? MeasurmentR { get; set; }

        [Display(AutoGenerateField = true, Name = "Изм. U")]
        public bool MeasurmentEnableU { get; set; }

        [Display(AutoGenerateField = true, Name = "min(+)U, В")]
        public float? MeasurmentMinU1 { get; set; }

        [Display(AutoGenerateField = true, Name = "max(+)U, В")]
        public float? MeasurmentMaxU1 { get; set; }

        [Display(AutoGenerateField = true, Name = "min(-)U, В")]
        public float? MeasurmentMinU2 { get; set; }

        [Display(AutoGenerateField = true, Name = "max(-)U, В")]
        public float? MeasurmentMaxU2 { get; set; }

        [Display(AutoGenerateField = true, Name = "R/max(+)U, В"), ReadOnly(true)]
        public float? MeasurmentMaxU1divideR { get => MeasurmentR / MeasurmentMaxU1; }

        [Display(AutoGenerateField = true, Name = "Изм. П")]
        public bool MeasurmentEnableP { get; set; }

        [Display(AutoGenerateField = true, Name = "П⮂, мкс")]
        public float? MeasurmentP1 { get; set; }

        [Display(AutoGenerateField = true, Name = "П⮃, мкс")]
        public float? MeasurmentP2 { get; set; }

        [Display(AutoGenerateField = true, Name = "П⮂/⮃, мкс"), ReadOnly(true)]
        public float? MeasurmentP1divideP2 { get => MeasurmentP1 / MeasurmentP2; }

        [Display(AutoGenerateField = true, Name = "Изм. Sфнд")]
        public bool FoundationEnableS { get; set; }

        [Display(AutoGenerateField = true, Name = "Sфнд, м/с")]
        public float? FoundationS { get; set; }

        [Display(AutoGenerateField = true, Name = "Изм. Sанк")]
        public bool AnchorEnableS { get; set; }

        [Display(AutoGenerateField = true, Name = "Sанк, м/с")]
        public float? AnchorS { get; set; }

        [Display(AutoGenerateField = true, Name = "Вид обследования")]
        public string? AnalysisType { get; set; }

        [Display(AutoGenerateField = true, Name = "Изм. наклона")]
        public bool EnableTilt { get; set; }

        [Display(AutoGenerateField = true, Name = "Наклон вдоль, °")]
        public float? TiltAlong{ get; set; }

        [Display(AutoGenerateField = true, Name = "Наклон поперек, °")]
        public float? TiltAcross { get; set; }

        [Display(AutoGenerateField = true, Name = "Дефекты"), BindedGridColumn(typeof(MastView))]
        public string? Defects { get; set; }

    }
}
