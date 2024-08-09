using Ardalis.Result;
using FastEndpoints;
using MediatR;
using PipelineProcess.api.Core.Records;
using PipelineProcess.api.UseCases.Services.Schemas.Queries;

namespace PipelineProcess.api.Web.Endpoints.Schemas;

public class GetAllSchemas : Endpoint<GetAllSchemas.GetAllSchemasRequest, Result<List<GetAllSchemaDto>>>
{
  private readonly IMediator _mediator;

  public GetAllSchemas(IMediator mediator)
  {
    _mediator = mediator;
  }

  public class GetAllSchemasRequest
  {
    public const string Route = "/api/Schema/All";
  }
  public override void Configure()
  {
    Post(GetAllSchemasRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Gets All Projects.";
      s.Description = "Gets All Projects.";
    });
    Tags([nameof(Projects)]);
  }
  public override async Task<Result<List<GetAllSchemaDto>>> ExecuteAsync(GetAllSchemasRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new GetAllSchemaQuery(), ct);
    if (result.IsSuccess)
      Response = result.Value;
    return result;
  }
}
