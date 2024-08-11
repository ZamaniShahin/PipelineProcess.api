﻿namespace PipelineProcess.api.Core.Records;

public class GetAllSchemaDto(string title, string description, DateTime createdAt)
{
  public string Title { get; set; } = title;
  public string? Description { get; set; } = description;
  public DateTime CreatedAt { get; set; } = createdAt;
}
