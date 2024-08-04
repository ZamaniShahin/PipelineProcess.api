using Ardalis.Result;
using Ardalis.SharedKernel;
using PipelineProcess.api.Core.Aggregates.SchemaAggregate;
using PipelineProcess.api.Core.Aggregates.SchemaAggregate.Specifications;

namespace PipelineProcess.api.UseCases.Services.Schemas.Commands;

public class UpdateSchemaCommand(string id, string title, string? description) : Ardalis.SharedKernel.ICommand<Result<string>>
{
  public string Title { get; set; } = !string.IsNullOrEmpty(title) ? title : string.Empty;
  public string? Description { get; set; } = description;
  public string Id { get; set; } = id;
}

public class UpdateSchemaCommandHandler(IRepository<Schema> repository)
  : ICommandHandler<UpdateSchemaCommand, Result<string>>
{
  private readonly IRepository<Schema> _repository = repository;

  public async Task<Result<string>> Handle(UpdateSchemaCommand request, CancellationToken cancellationToken)
  {
    var schema = await _repository.FirstOrDefaultAsync(new GetSchemaSpec(request.Id, false), cancellationToken);
    if (schema is null)
      return Result<string>.NotFound();
    schema.Update(request.Title, request.Description);
    
    
    await _repository.UpdateAsync(schema, cancellationToken);
    await _repository.SaveChangesAsync(cancellationToken);

    return Result<string>.Success(schema.Id.ToString());
  }
}
