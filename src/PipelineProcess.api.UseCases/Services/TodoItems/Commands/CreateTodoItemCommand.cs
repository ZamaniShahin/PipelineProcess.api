using Ardalis.Result;
using Ardalis.SharedKernel;
using PipelineProcess.api.Core.Aggregates.TodoItemAggregate;

namespace PipelineProcess.api.UseCases.Services.TodoItems.Commands;

public class CreateTodoItemCommand(string title, string description) : ICommand<Result<string>>
{
  public string Title { get; set; } = title;
  public string Description { get; set; } = description;
  
}

public class CreateTodoItemCommandHandler(IRepository<TodoItem> repository)
  : ICommandHandler<CreateTodoItemCommand, Result<string>>
{
  private readonly IRepository<TodoItem> _repository = repository;
  public async Task<Result<string>> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
  {
    var todoItem = new TodoItem(request.Title, request.Description);

    await _repository.AddAsync(todoItem, cancellationToken);
    await _repository.SaveChangesAsync(cancellationToken);

    return Result<string>.Success(todoItem.Id.ToString());
  }
}
