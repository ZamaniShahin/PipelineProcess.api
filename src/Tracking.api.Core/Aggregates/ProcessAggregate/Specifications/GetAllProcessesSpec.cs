using Ardalis.Specification;
using Tracking.api.Core.Records.ProcessDtos;

namespace Tracking.api.Core.Aggregates.ProcessAggregate.Specifications;

public class GetAllProcessesSpec : Specification<Process, GetProcessDto>
{
  public GetAllProcessesSpec(bool AsReadOnly = true)
  {
    Query.AsTracking(AsReadOnly);

    Query.Select(item => new GetProcessDto(
      item.Title,
      item.Description,
      item.CreatedAt));
  }
}
