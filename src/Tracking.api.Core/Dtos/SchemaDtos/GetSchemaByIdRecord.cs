namespace Tracking.api.Core.Records.SchemaDtos;

public class GetSchemaByIdDto(string title, string description, DateTime createdAt)
{
  public string Title { get; init; } = title;
  public string? Description { get; init; } = description;
  public DateTime CreatedAt { get; init; } = createdAt;
}
