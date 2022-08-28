using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOHome.Common.DataModels.Requests;

public class ExerciseCreateModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<string> Images { get; set; }  
}
