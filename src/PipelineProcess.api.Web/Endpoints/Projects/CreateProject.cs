﻿using Ardalis.Result;
using FastEndpoints;
using MediatR;
using Microsoft.Build.Framework;
using PipelineProcess.api.UseCases.Services.Projects;

namespace PipelineProcess.api.Web.Endpoints.Projects;

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
      s.ExampleRequest = new CreateProjectRequest { SchemaId = Guid.Empty, Description = "Project Description"};
    });
    Tags([nameof(Projects)]);
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
    public Guid SchemaId { get; set; }
    [Required]
    public string? Description { get; set; }
  }
}