using Tracking.api.Core.Records.ProjectDtos;
using Tracking.api.UseCases.Services.Projects.Queries;

namespace Tracking.api.Web.Endpoints.ProjectEndpoints;

public class GetAllProjects: Endpoint<EmptyRequest, Result<List<GetProjectRecord>>>
{
  private readonly IMediator _mediator;

  public GetAllProjects(IMediator mediator)
  {
    _mediator = mediator;
  }
  
  public override void Configure()
  {
    Get(GetAllProjectsRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Gets All Projects.";
      s.Description = "Gets All Projects.";
    });
    Tags(nameof(ProjectEndpoints));
  }
  public override async Task<Result<List<GetProjectRecord>>> ExecuteAsync(EmptyRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new GetAllProjectsQuery(), ct);
    if (result.IsSuccess)
      Response = result.Value;
    return result;
  }
  public class GetAllProjectsRequest
  {
    public const string Route = "/api/Project/All";
  }
}
