using FluentValidation;
using Microsoft.Build.Framework;
using Tracking.api.Infrastructure.Data.Config;
using Tracking.api.UseCases.Services.Schemas.Commands;

namespace Tracking.api.Web.Endpoints.Schemas;

public class UpdateSchema: Endpoint<UpdateSchema.UpdateSchemaRequest, Result<string>>
{
  private readonly IMediator _mediator;

  public UpdateSchema(IMediator mediator)
  {
    _mediator = mediator;
  }
  
  
  public override void Configure()
  {
    Put(UpdateSchemaRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Update a Schema.";
      s.Description = "Update a Schema. A valid Title is required.";
      s.ExampleRequest = new UpdateSchemaRequest { Title = "Schema Title", Description = "Schema Description"};
    });
    Tags([nameof(Schemas)]);
  }

  public override async Task<Result<string>> ExecuteAsync(UpdateSchemaRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new UpdateSchemaCommand(req.SchemaId ?? string.Empty, req.Title ?? string.Empty, req.Description), ct);
    if (result.IsSuccess)
      Response = result.Value;
    return result;
  }

  public class UpdateSchemaRequest
  {
    public const string Route = "/api/Schema/{SchemaId}/Update";
    public static string BuildRoute(string schemaId) => Route.Replace("{SchemaId}", schemaId.ToString());
    public string? SchemaId { get; set; }
    [Required]
    public string? Title { get; set; }
    public string? Description { get; set; }
  }
  
  public class UpdateSchemaValidator : Validator<UpdateSchemaRequest>
  {
    public UpdateSchemaValidator()
    {
      RuleFor(x => x.Title)
        .NotEmpty()
        .WithMessage("Title is required.")
        .MinimumLength(2)
        .MaximumLength(DataSchemaConstants.DEFAULT_TITLE_LENGTH);
      RuleFor(x => x.Description)
        .NotEmpty()
        .WithMessage("Fill The Description or leave it null")
        .MinimumLength(10)
        .MaximumLength(DataSchemaConstants.DEFAULT_DESCRIPTION_LENGTH);
      
      RuleFor(x => x.SchemaId)
        .NotEmpty()
        .WithMessage("Fill The Schema.")
        .MinimumLength(10)
        .MaximumLength(DataSchemaConstants.DEFAULT_ID_LENGTH);
    }
  }
}
