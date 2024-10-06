using Microsoft.Build.Framework;
using PipelineProcess.api.UseCases.Services.Projects.Commands;

namespace PipelineProcess.api.Web.Endpoints.ProjectEndpoints;

public class CreateProject: Endpoint<CreateProject.CreateProjectRequest, Result<string>>
{
  private readonly IMediator _mediator;

  public CreateProject(IMediator mediator)
  {
    _mediator = mediator;
  }
  public override void Configure()
  {
    Post(CreateProjectRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Create a new Project.";
      s.Description = "Create a new Project.";
      s.ExampleRequest = new CreateProjectRequest
      {
        Description = "Project Description",
        SchemaId = Guid.Parse("1B8E5401-E7A5-486C-AB97-48868C1EF0CF")
        
      };
      s.ResponseExamples.Add(200, Result<string>.Success("Ha HA Ha"));
      s.ResponseExamples.Add(404, Result<string>.NotFound("Nothing-Found"));
    });
    Tags(nameof(ProjectEndpoints));
  }
  public override async Task<Result<string>> ExecuteAsync(CreateProjectRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new CreateProjectCommand(req.SchemaId, req.Description ?? string.Empty), ct);
    if (result.IsSuccess)
      Response = result.Value;
    return result;
  }
  public class CreateProjectRequest
  {
    public const string Route = "/api/Project/{SchemaId}/Create";
    public static string BuildRoute(string schemaId) => Route.Replace("{SchemaId}", schemaId.ToString());
    [BindFrom("SchemaId")]public Guid SchemaId { get; set; }
    public string? Description { get; set; }
  }
}
