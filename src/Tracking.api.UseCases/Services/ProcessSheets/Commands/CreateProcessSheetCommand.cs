using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Tracking.api.UseCases.Services.ProcessSheets.Commands;

public class CreateProcessSheetCommand(Guid? projectId, Guid? todoItemId) : Ardalis.SharedKernel.ICommand<Result<Guid>>
{
  public Guid? ProjectId { get; init; } = projectId;
  public Guid? TodoItemId { get; set; } = todoItemId;
}

public class CreateProcessSheetCommandHandler : ICommandHandler<CreateProcessSheetCommand, Result<Guid>>
{
  public Task<Result<Guid>> Handle(CreateProcessSheetCommand request, CancellationToken cancellationToken)
  {
    // todo
    throw new NotImplementedException();
  }
}
