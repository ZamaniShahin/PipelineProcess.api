using Ardalis.Specification;
using Tracking.api.Core.Records.ProjectDtos;

namespace Tracking.api.Core.Aggregates.ProjectAggregate.Specifications;

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
