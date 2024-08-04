using Ardalis.Result;
using FastEndpoints;
using FluentValidation;
using MediatR;
using Microsoft.Build.Framework;
using PipelineProcess.api.Infrastructure.Data.Config;
using PipelineProcess.api.UseCases.Services.Schemas.Commands;

namespace PipelineProcess.api.Web.Endpoints.Schemas;

public class CreateSchema: Endpoint<CreateSchema.CreateSchemaRequest, Result<string>>
{
  private readonly IMediator _mediator;

  public CreateSchema(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(CreateSchemaRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Create a new Schema.";
      s.Description = "Create a new Schema. A valid Title is required.";
      s.ExampleRequest = new CreateSchemaRequest { Title = "Schema Title", Description = "Schema Description"};
    });
    Tags([nameof(Schemas)]);
  }

  public override async Task<Result<string>> ExecuteAsync(CreateSchemaRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new CreateSchemaCommand(req.Title ?? string.Empty, req.Description), ct);
    if (result.IsSuccess)
      Response = result.Value;
    return result;
  }

  public class CreateSchemaRequest
  {
    public const string Route = "/api/Schema/Create";

    [Required]
    public string? Title { get; set; }
    public string? Description { get; set; }
  }
  
  public class CreateSchemaValidator : Validator<CreateSchemaRequest>
  {
    public CreateSchemaValidator()
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
    }
  }
}
