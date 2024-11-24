namespace Tracking.api.Core.Records.ProjectDtos;

public record GetProjectRecord(
  Guid ProjectId,
  string? ProjectDescription
  );
