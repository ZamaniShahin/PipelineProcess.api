using PipelineProcess.api.UseCases.Services.TodoItems.Commands;

namespace PipelineProcess.api.Web.Endpoints.ProcessEndpoints;

public class CreateTodoItem : Endpoint<CreateTodoItem.CreateTodoItemRequest, Result<string>>
{
  private readonly IMediator _mediator;

  public CreateTodoItem(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(CreateTodoItemRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Create a new TodoItem.";
      s.Description = "Create a new TodoItem. A valid Title is required.";
    });
    Tags([nameof(CreateTodoItemRequest)]);
  }

  public override async Task<Result<string>> ExecuteAsync(CreateTodoItemRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new CreateTodoItemCommand(req.Title ?? string.Empty, req.Description ?? string.Empty), ct);
    if (result.IsSuccess)
      Response = result.Value;
    return result;
  }
  public class CreateTodoItemRequest
  {
    public const string Route = "/api/TodoItem/Create";
    public string? Title { get; set; }
    public string? Description { get; set; }
  }
}
