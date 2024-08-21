using Ardalis.Specification;
using PipelineProcess.api.Core.Records.ProcessDtos;

namespace PipelineProcess.api.Core.Aggregates.ProcessAggregate.Specifications;

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
