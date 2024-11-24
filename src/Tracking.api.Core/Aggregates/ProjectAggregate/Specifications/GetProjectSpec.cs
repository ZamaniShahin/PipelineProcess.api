using Ardalis.Specification;

namespace Tracking.api.Core.Aggregates.ProjectAggregate.Specifications;

public class GetProjectSpec : Specification<Project>
{
  public GetProjectSpec(Guid projectId, bool AsReadOnly = true)
  {
    Query
      .Where(x => x.Id == projectId)
      .AsNoTracking(AsReadOnly);

    // Query
    //   .Select(x => new GetProjectByIdRecord(
    //     x.Description, x.Id
    //     ));
  }
}
