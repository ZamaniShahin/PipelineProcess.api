using System.ComponentModel.DataAnnotations;
using PipelineProcess.api.UseCases.Services.ProcessSheets.Commands;
namespace PipelineProcess.api.Web.Endpoints.ProcessSheetEndpoints;

public class
  CreateProcessSheetEndpoint : Endpoint<CreateProcessSheetEndpoint.CreateProjectTodoItemRequest, Result<Guid>>
{
  private readonly IMediator _mediator;

  public CreateProcessSheetEndpoint(IMediator mediator)
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
    var result = await _mediator.Send(new CreateProcessSheetCommand(req.ProjectId, req.TodoItemId), ct);
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
