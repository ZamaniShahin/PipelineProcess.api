using Ardalis.Result;
using FastEndpoints;
using MediatR;
using PipelineProcess.api.Core.Records;
using PipelineProcess.api.UseCases.Services.Projects.Queries;

namespace PipelineProcess.api.Web.Endpoints.Projects;

public class GetAllProjects: Endpoint<GetAllProjects.GetAllProjectsRequest, Result<List<GetProjectRecord>>>
{
  private readonly IMediator _mediator;

  public GetAllProjects(IMediator mediator)
  {
    _mediator = mediator;
  }
  
  public override void Configure()
  {
    Post(GetAllProjectsRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Gets All Projects.";
      s.Description = "Gets All Projects.";
    });
    Tags([nameof(Projects)]);
  }
  public override async Task<Result<List<GetProjectRecord>>> ExecuteAsync(GetAllProjectsRequest req, CancellationToken ct)
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
