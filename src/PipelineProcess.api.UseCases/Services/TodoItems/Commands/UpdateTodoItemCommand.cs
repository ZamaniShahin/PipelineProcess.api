using Ardalis.Result;
using Ardalis.SharedKernel;
using PipelineProcess.api.Core.Aggregates.ProcessAggregate;

namespace PipelineProcess.api.UseCases.Services.TodoItems.Commands;

public class UpdateTodoItemCommand(string id, string title, string description)
  : Ardalis.SharedKernel.ICommand<Result<string>>
{
  public string Title { get; set; } = !string.IsNullOrEmpty(title) ? title : string.Empty;
  public string Description { get; set; } = description;
  public string Id { get; set; } = id;
}

public class UpdateTodoItemCommandHandler(IRepository<Process> repository)
  : ICommandHandler<UpdateTodoItemCommand, Result<string>>
{
  private readonly IRepository<Process> _repository = repository;

  public async Task<Result<string>> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
  {
    var todoItem = await _repository.GetByIdAsync(request.Id, cancellationToken);

    if (todoItem is null)
      return Result<string>.NotFound();

    todoItem.Update(request.Title, request.Description);

    await _repository.UpdateAsync(todoItem, cancellationToken);
    await _repository.SaveChangesAsync(cancellationToken);

    return Result<string>.Success(todoItem.Id.ToString());
  }
}
