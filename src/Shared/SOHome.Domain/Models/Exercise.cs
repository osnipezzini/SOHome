using SOHome.Common.Models;

namespace SOHome.Domain.Models;

public class Exercise
{
    public int Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ExerciseType ExerciseType { get; set; }
    public List<string> Images { get; set; } = new List<string>();
    public string UserId { get; set; }
    public string Id { get; set; }
}
