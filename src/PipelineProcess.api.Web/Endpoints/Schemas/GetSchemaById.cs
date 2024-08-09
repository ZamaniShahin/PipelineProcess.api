using Ardalis.Result;
using FastEndpoints;
using MediatR;
using Microsoft.Build.Framework;
using PipelineProcess.api.Core.Records;
using PipelineProcess.api.UseCases.Services.Schemas.Queries;

namespace PipelineProcess.api.Web.Endpoints.Schemas;

public class GetSchemaById : Endpoint<GetSchemaById.GetSchemaByIdRequest, Result<GetSchemaByIdDto>>
{
  private readonly IMediator _mediator;

  public GetSchemaById(IMediator mediator)
  {
    _mediator = mediator;
  }
  public override void Configure()
  {
    Post(GetSchemaByIdRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Gets An Schema By Id.";
      s.Description = "Gets An Schema By Id.";
    });
    Tags([nameof(Schemas)]);
  }
  public override async Task<Result<GetSchemaByIdDto>> ExecuteAsync(GetSchemaByIdRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new GetSchemaByIdQuery(req.SchemaId.ToString()), ct);
    if (result.IsSuccess)
      Response = result.Value;
    return result;
  }

  public class GetSchemaByIdRequest
  {
    public const string Route = "/api/Schema/{SchemaId}/Info";
    public static string BuildRoute(Guid schemaId) => Route.Replace("{SchemaId}", schemaId.ToString());
    [Required] public Guid SchemaId { get; set; }
  }
}
