namespace PipelineProcess.api.Core.Records;

public record GetProjectRecord(
  Guid ProjectId,
  string? ProjectDescription
  );
