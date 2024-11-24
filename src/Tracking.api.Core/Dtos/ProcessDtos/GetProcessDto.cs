namespace Tracking.api.Core.Records.ProcessDtos;

public class GetProcessDto(string title, string description, DateTime createdAt)
{
  public string Title { get; set; } = title;
  public string? Description { get; set; } = description;
  public DateTime CreatedAt { get; set; } = createdAt;
}
