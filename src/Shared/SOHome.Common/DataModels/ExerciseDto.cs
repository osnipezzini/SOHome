using SOHome.Common.Models;

using System.Collections.Generic;

namespace SOHome.Common.DataModels;

public class ExerciseDto
{
    public int Code { get; set; }
    public string Name { get; set; }
    public ExerciseType Type { get; set; }
    public string Description { get; set; }
    public List<string> Images { get; set; }

}
