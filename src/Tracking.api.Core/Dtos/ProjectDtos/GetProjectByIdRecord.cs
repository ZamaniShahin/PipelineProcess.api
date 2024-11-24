namespace Tracking.api.Core.Records.ProjectDtos;

public record GetProjectByIdRecord(
  string Description,
  Guid ProjectId
  );
