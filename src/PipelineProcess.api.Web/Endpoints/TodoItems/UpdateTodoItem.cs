using Microsoft.Build.Framework;
using PipelineProcess.api.UseCases.Services.TodoItems.Commands;

namespace PipelineProcess.api.Web.Endpoints.TodoItems;

public class UpdateTodoItem : Endpoint<UpdateTodoItem.UpdateTodoItemRequest, Result<string>>
{
  private readonly IMediator _mediator;

  public UpdateTodoItem(IMediator mediator)
  {
    _mediator = mediator;
  }
  public class UpdateTodoItemRequest
  {
    public const string Route = "/api/Schema/{TodoItemId}/Update";
    public static string BuildRoute(string todoItemId) => Route.Replace("{TodoItemId}", todoItemId.ToString());
    public string? TodoItemId { get; set; }
    [Required]
    public string? Title { get; set; }
    public string? Description { get; set; }
  }
  public override void Configure()
  {
    Put(UpdateTodoItemRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Update a TodoItem.";
      s.Description = "Update a TodoItem. A valid Title is required.";
    });
    Tags([nameof(Schemas)]);
  }

  public override async Task<Result<string>> ExecuteAsync(UpdateTodoItemRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new UpdateTodoItemCommand(
      req.TodoItemId ?? string.Empty,
      req.Title ?? string.Empty,
      req.Description ?? string.Empty), ct);
    
    
    if (result.IsSuccess)
      Response = result.Value;
    
    return result;
  }
}
