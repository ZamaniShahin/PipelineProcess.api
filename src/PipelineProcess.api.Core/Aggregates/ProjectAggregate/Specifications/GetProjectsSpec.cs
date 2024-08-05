using Ardalis.Specification;
using PipelineProcess.api.Core.Records;

namespace PipelineProcess.api.Core.Aggregates.ProjectAggregate.Specifications;

public class GetProjectsSpec : Specification<Project, GetProjectRecord>
{
  public GetProjectsSpec(bool AsReadOnly = true)
  {
    Query
      .AsNoTracking(AsReadOnly);

    Query
      .Select(x => new GetProjectRecord(
        x.Id, x.Description
      ));
  }
  
}
