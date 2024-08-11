using Ardalis.Result;
using Ardalis.SharedKernel;
using PipelineProcess.api.Core.Aggregates.TodoItemAggregate;
using PipelineProcess.api.Core.Aggregates.TodoItemAggregate.Specifications;
using PipelineProcess.api.Core.Records;

namespace PipelineProcess.api.UseCases.Services.TodoItems.Queries;

public class GetTodoItemByIdQuery(string id) : IQuery<Result<GetTodoItemDto>>
{
  public string Id { get; set; } = id;
}

public class GetTodoItemByIdQueryHandler(IReadRepository<TodoItem> repository)
  : IQueryHandler<GetTodoItemByIdQuery, Result<GetTodoItemDto>>
{
  private readonly IReadRepository<TodoItem> _repository = repository;
  public async Task<Result<GetTodoItemDto>> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
  {
    var todoItem = await _repository.FirstOrDefaultAsync(new GetTodoItemByIdSpec(request.Id), cancellationToken);

    if (todoItem is null)
      return Result<GetTodoItemDto>.NotFound();
    
    return Result<GetTodoItemDto>.Success(todoItem);
    
  }
}
