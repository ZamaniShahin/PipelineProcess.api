using Ardalis.Result;
using Ardalis.SharedKernel;
using Tracking.api.Core.Aggregates.SchemaAggregate;
using Tracking.api.Core.Aggregates.SchemaAggregate.Specifications;
using Tracking.api.Core.Records.SchemaDtos;

namespace Tracking.api.UseCases.Services.Schemas.Queries;

public class GetAllSchemaQuery() : IQuery<Result<List<GetAllSchemaDto>>>
{
}

public class GetAllSchemaQueryHandler(IReadRepository<Schema> _repository)
  : IQueryHandler<GetAllSchemaQuery, Result<List<GetAllSchemaDto>>>
{
  public async Task<Result<List<GetAllSchemaDto>>> Handle(GetAllSchemaQuery request,
    CancellationToken cancellationToken)
  {
    var schema = await _repository.ListAsync(new GetAllSchemaSpec(),
      cancellationToken);

    return Result<List<GetAllSchemaDto>>.Success(schema.Count > 0 ? schema : []);
  }
}
