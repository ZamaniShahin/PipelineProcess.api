using Ardalis.Result;
using Ardalis.SharedKernel;
using PipelineProcess.api.Core.Aggregates.TodoItemAggregate;
using PipelineProcess.api.Core.Aggregates.TodoItemAggregate.Specifications;
using PipelineProcess.api.Core.Records;

namespace PipelineProcess.api.UseCases.Services.TodoItems.Queries;

public class GetAllTodoItemsQuery() : IQuery<Result<List<GetTodoItemDto>>>
{
}

public class GetAllTodoItemsQueryHandler(IReadRepository<TodoItem> repository)
  : IQueryHandler<GetAllTodoItemsQuery, Result<List<GetTodoItemDto>>>
{
  private readonly IReadRepository<TodoItem> _repository = repository;

  public async Task<Result<List<GetTodoItemDto>>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
  {
    var todoItem = await _repository.ListAsync(new GetAllTodoItemsSpec(), cancellationToken);

    return Result<List<GetTodoItemDto>>.Success(todoItem.Count > 0 ? todoItem : []);
  }
}
