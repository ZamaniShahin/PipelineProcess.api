using Microsoft.Build.Framework;
using PipelineProcess.api.Core.Records;
using PipelineProcess.api.UseCases.Services.Projects.Queries;

namespace PipelineProcess.api.Web.Endpoints.Projects;

public class GetProjectById : Endpoint<GetProjectById.GetProjectByIRequest, Result<GetProjectByIdRecord>>
{
  private readonly IMediator _mediator;

  public GetProjectById(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(GetProjectByIRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Get's a Project.";
      s.Description = "Get's a Project.";
      s.ExampleRequest = new GetProjectByIRequest { ProjectId = Guid.Empty};
    });
    Tags([nameof(Projects)]);
  }

  public override async Task<Result<GetProjectByIdRecord>> ExecuteAsync(GetProjectByIRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new GetProjectByIdQuery(req.ProjectId), ct);
    if (result.IsSuccess)
      Response = result.Value;
    return result;
  }

  public class GetProjectByIRequest
  {
    public const string Route = "/api/Project/{ProjectId}/Info";
    public static string BuildRoute(Guid projectId) => Route.Replace("{ProjectId}", projectId.ToString());
    [Required] public Guid ProjectId { get; set; }
  }
}
