﻿using MediatR;

using SOHome.Common.Models;

using System.Collections.Generic;

namespace SOHome.Common.DataModels.Requests;

public class ExerciseCreateModel : IRequest
{
    public int? Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ExerciseType ExerciseType { get; set; }
    public List<string> Images { get; set; }
}
