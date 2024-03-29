﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CatenarySupport.Providers.View
{
    public class DistrictView: IViewObject
    {
        [Display(AutoGenerateField = false), ReadOnly(true)]
        public string? UUID { get; set; }

        [Display(AutoGenerateField = true, Name = "Участок")]
        public string? District { get; set; }

        [Display(AutoGenerateField = true, Name = "Грунт"),]
        public string? SoilCharacteristics { get; set; }

        [Display(AutoGenerateField = true, Name = "Установленная скорость")]
        public int? MaxSpeed { get; set; }
    }
}
