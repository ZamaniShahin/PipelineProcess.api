namespace PipelineProcess.api.Core.Records;

public record GetProjectByIdRecord(
  string Description,
  Guid ProjectId
  );
