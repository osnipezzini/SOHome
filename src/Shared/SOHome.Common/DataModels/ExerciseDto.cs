using SOHome.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOHome.Common.DataModels;

public class ExerciseDto
{
    public string Name { get; set; }
    public ExerciseType Type { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }

}
