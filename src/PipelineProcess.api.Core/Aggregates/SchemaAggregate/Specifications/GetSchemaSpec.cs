using Ardalis.Specification;

namespace PipelineProcess.api.Core.Aggregates.SchemaAggregate.Specifications;

public class GetSchemaSpec : Specification<Schema>
{
  public GetSchemaSpec(string id, bool AsReadOnly = true)
  {
    Query.Where(x => x.Id == Guid.Parse(id))
      .AsTracking(AsReadOnly);
  }
}
