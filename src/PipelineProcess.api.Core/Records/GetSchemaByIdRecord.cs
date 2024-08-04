namespace PipelineProcess.api.Core.Records;

public class GetSchemaByIdDto(string title, string description, DateTime createdAt)
{
  public string Title { get; init; } = title;
  public string? Description { get; init; } = description;
  public DateTime CreatedAt { get; init; } = createdAt;
}
