using Ardalis.Specification;
using PipelineProcess.api.Core.Records.ProjectDtos;

namespace PipelineProcess.api.Core.Aggregates.ProjectAggregate.Specifications;

public class GetAllProjectsSpec : Specification<Project, GetProjectByIdRecord>
{
  public GetAllProjectsSpec(Guid projectId, bool AsReadOnly = true)
  {
    Query
      .Where(x => x.Id == projectId)
      .AsNoTracking(AsReadOnly);

    Query
      .Select(x => new GetProjectByIdRecord(x.Description, x.Id));
  }
}
