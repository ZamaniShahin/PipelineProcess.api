using Ardalis.Result;
using Ardalis.SharedKernel;
using Tracking.api.Core.Aggregates.ProcessAggregate;

namespace Tracking.api.UseCases.Services.TodoItems.Commands;

public class CreateTodoItemCommand(string title, string description) : ICommand<Result<string>>
{
  public string Title { get; set; } = title;
  public string Description { get; set; } = description;
  
}

public class CreateTodoItemCommandHandler(IRepository<Process> repository)
  : ICommandHandler<CreateTodoItemCommand, Result<string>>
{
  private readonly IRepository<Process> _repository = repository;
  public async Task<Result<string>> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
  {
    var todoItem = new Process(request.Title, request.Description);

    await _repository.AddAsync(todoItem, cancellationToken);
    await _repository.SaveChangesAsync(cancellationToken);

    return Result<string>.Success(todoItem.Id.ToString());
  }
}
