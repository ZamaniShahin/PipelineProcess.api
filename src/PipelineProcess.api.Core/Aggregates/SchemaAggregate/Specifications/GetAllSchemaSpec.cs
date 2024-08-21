using Ardalis.Specification;
using PipelineProcess.api.Core.Records.SchemaDtos;

namespace PipelineProcess.api.Core.Aggregates.SchemaAggregate.Specifications;

public class GetAllSchemaSpec : Specification<Schema, GetAllSchemaDto>
{
  public GetAllSchemaSpec(bool AsReadOnly = true)
  {
    Query
      .AsTracking(AsReadOnly);

    Query
      .Select(x => new GetAllSchemaDto(
        x.Title,
        x.Description ?? string.Empty,
        x.CreatedAt));
  }
}
