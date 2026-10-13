using System;

namespace server.Dtos.Activity;

public class CreateActivityDto
{
    public string Name { get; set; } = string.Empty;
    public string Desc { get; set; } = string.Empty;
    public int MinTime { get; set; }
    public bool IsPrioritized { get; set; }
    public int Enjoyment { get; set; }

    public int? CategoryId { get; set; }
}
