using Ardalis.Result;
using Ardalis.SharedKernel;

namespace PipelineProcess.api.UseCases.Services.ProjectTodoItems;

public class CreateProjectTodoItemCommand(Guid? projectId, Guid? todoItemId) : Ardalis.SharedKernel.ICommand<Result<Guid>>
{
  public Guid? ProjectId { get; init; } = projectId;
  public Guid? TodoItemId { get; set; } = todoItemId;
}

public class CreateProjectTodoItemCommandHandler : ICommandHandler<CreateProjectTodoItemCommand, Result<Guid>>
{
  public Task<Result<Guid>> Handle(CreateProjectTodoItemCommand request, CancellationToken cancellationToken)
  {
    // todo
    throw new NotImplementedException();
  }
}
