using Ardalis.Specification;
using Tracking.api.Core.Records.ProcessDtos;

namespace Tracking.api.Core.Aggregates.ProcessAggregate.Specifications;

public class GetProcessByIdSpec : Specification<Process, GetProcessDto>
{
  public GetProcessByIdSpec(string id , bool AsReadOnly = true)
  {
    Query.AsTracking(AsReadOnly);
    Query.Select(x => new GetProcessDto(
      x.Title,
      x.Description,
      x.CreatedAt
    ));
  }
}
