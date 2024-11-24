using Ardalis.Specification;
using Tracking.api.Core.Records.SchemaDtos;

namespace Tracking.api.Core.Aggregates.SchemaAggregate.Specifications;

public class GetSchemaByIdSpec : Specification<Schema, GetSchemaByIdDto>
{
  public GetSchemaByIdSpec(string id , bool AsReadOnly = true)
  {
    Query
      .Where(x => x.Id == Guid.Parse(id))
      .AsTracking(AsReadOnly);

    Query
      .Select(x => new GetSchemaByIdDto(
        x.Title,
        x.Description ?? string.Empty,
        x.CreatedAt));
  }
}
