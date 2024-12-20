﻿using Ardalis.Result;
using Ardalis.SharedKernel;
using Tracking.api.Core.Aggregates.SchemaAggregate;

namespace Tracking.api.UseCases.Services.Schemas.Commands;

public class CreateSchemaCommand(string title, string? description, uint count)
  : ICommand<Result<string>>
{
  public string Title { get; set; } = !string.IsNullOrEmpty(title) ? title : string.Empty;
  public string? Description { get; set; } = description;
  public uint Count { get; set; } = count;
}

public class CreateSchemaCommandHandler(IRepository<Schema> repository)
  : ICommandHandler<CreateSchemaCommand, Result<string>>
{
  private readonly IRepository<Schema> _repository = repository;

  public async Task<Result<string>> Handle(CreateSchemaCommand request, CancellationToken cancellationToken)
  {
    var schema = new Schema(request.Title, request?.Description, request.Count);

    await _repository.AddAsync(schema, cancellationToken);
    await _repository.SaveChangesAsync(cancellationToken);

    return Result<string>.Success(schema.Id.ToString());
  }
}
