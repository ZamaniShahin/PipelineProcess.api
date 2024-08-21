namespace PipelineProcess.api.Core.Records.ProjectDtos;

public record GetProjectByIdRecord(
  string Description,
  Guid ProjectId
  );
