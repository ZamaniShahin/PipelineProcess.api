using System.ComponentModel.DataAnnotations;
using PipelineProcess.api.UseCases.Services.ProjectTodoItems;

namespace PipelineProcess.api.Web.Endpoints.ProjectTodoItems;

public class
  CreateProjectTodoItemEndpoint : Endpoint<CreateProjectTodoItemEndpoint.CreateProjectTodoItemRequest, Result<Guid>>
{
  private readonly IMediator _mediator;

  public CreateProjectTodoItemEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(CreateProjectTodoItemRequest.Route);
    AllowAnonymous(Http.POST);
    Summary(s =>
    {
      s.Summary = "Create a new ProjectTodoItem";
      s.Description = "Create a new ProjectTodoItem";
    });
  }

  public override async Task<Result<Guid>> ExecuteAsync(CreateProjectTodoItemRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new CreateProjectTodoItemCommand(req.ProjectId, req.TodoItemId), ct);
    if (result.IsSuccess)
      Response = result.Value;
    return result;
  }

  public class CreateProjectTodoItemRequest
  {
    public const string Route = "/api/ProjectTodoItem/{ProjectId}/Create/TodoItemId";

    public static string BuildRoute(string projectId, string todoItemId) =>
      Route.Replace("{ProjectId}", projectId)
        .Replace("{TodoItemId", todoItemId);

    public Guid ProjectId { get; set; }
    [Required] public Guid? TodoItemId { get; set; }
  }
}
