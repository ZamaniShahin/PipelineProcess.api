namespace Tracking.api.Core.Records.SchemaDtos;

public class GetAllSchemaDto(string title, string description, DateTime createdAt)
{
  public string Title { get; set; } = title;
  public string? Description { get; set; } = description;
  public DateTime CreatedAt { get; set; } = createdAt;
}
