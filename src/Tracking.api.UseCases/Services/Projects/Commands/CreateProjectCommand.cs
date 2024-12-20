﻿using Ardalis.Result;
using Ardalis.SharedKernel;
using Tracking.api.Core.Aggregates.ProjectAggregate;

namespace Tracking.api.UseCases.Services.Projects.Commands;

public class CreateProjectCommand(Guid projectId, string description) : Ardalis.SharedKernel.ICommand<Result<string>>
{
  public Guid ProjectId { get; set; } = projectId;
  public string? Description { get; set; } = description;
}

public class CreateProjectCommandHandler(IRepository<Project> repository)
  : ICommandHandler<CreateProjectCommand, Result<string>>
{
  private readonly IRepository<Project> _repository = repository;

  public async Task<Result<string>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
  {
    var project = new Project(request.Description ?? String.Empty, request.ProjectId);

    await _repository.AddAsync(project, cancellationToken);
    await _repository.SaveChangesAsync(cancellationToken);

    return Result<string>.Success(project.Id.ToString());
  }
}
