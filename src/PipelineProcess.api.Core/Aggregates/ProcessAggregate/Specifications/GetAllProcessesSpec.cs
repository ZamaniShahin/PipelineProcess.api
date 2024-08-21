using Ardalis.Specification;
using PipelineProcess.api.Core.Records.ProcessDtos;

namespace PipelineProcess.api.Core.Aggregates.ProcessAggregate.Specifications;

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
