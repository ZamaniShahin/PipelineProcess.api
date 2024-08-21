using Ardalis.Result;
using Ardalis.SharedKernel;
using PipelineProcess.api.Core.Aggregates.SchemaAggregate;
using PipelineProcess.api.Core.Aggregates.SchemaAggregate.Specifications;
using PipelineProcess.api.Core.Records.SchemaDtos;

namespace PipelineProcess.api.UseCases.Services.Schemas.Queries;

public class GetSchemaByIdQuery(string id) : IQuery<Result<GetSchemaByIdDto>>
{
  public string Id { get; set; } = id;
}

public class GetSchemaByIdQueryHandler(IReadRepository<Schema> repository)
  : IQueryHandler<GetSchemaByIdQuery, Result<GetSchemaByIdDto>>
{
  private readonly IReadRepository<Schema> _repository = repository;
  public async Task<Result<GetSchemaByIdDto>> Handle(GetSchemaByIdQuery request, CancellationToken cancellationToken)
  {
    var schema = await _repository.FirstOrDefaultAsync(new GetSchemaByIdSpec(request.Id),
      cancellationToken);

    if (schema is null)
      return Result.NotFound();

    return Result<GetSchemaByIdDto>.Success(schema);
  }
}


