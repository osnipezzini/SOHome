using System.ComponentModel.DataAnnotations;

namespace SOHome.Common.Models;

public enum ExerciseType
{
    [Display(Description = "Braços")]
    Arms,
    [Display(Description = "Antebraços")]
    ForeArms,
    [Display(Description = "Ombros")]
    Shoulders,
    [Display(Description = "Peitoral")]
    Breastplate,
    [Display(Description = "Costas")]
    Back,
    [Display(Description = "Pernas")]
    Legs,
    [Display(Description = "Gluteos")]
    Glutes,
    [Display(Description = "Abdomen")]
    Abdomen
}
