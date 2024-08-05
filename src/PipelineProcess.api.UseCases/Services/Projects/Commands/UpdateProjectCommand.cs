using Ardalis.Result;
using Ardalis.SharedKernel;
using PipelineProcess.api.Core.Aggregates.ProjectAggregate;
using PipelineProcess.api.Core.Aggregates.ProjectAggregate.Specifications;

namespace PipelineProcess.api.UseCases.Services.Projects;

public class UpdateProjectCommand(Guid projectId, string description) : Ardalis.SharedKernel.ICommand<Result<string>>
{
  public Guid ProjectId { get; set; } = projectId;
  public string? Description { get; set; } = description;
}
public class UpdateProjectCommandHandler(IRepository<Project> repository)
  : ICommandHandler<CreateProjectCommand, Result<string>>
{
  private readonly IRepository<Project> _repository = repository;
  public async Task<Result<string>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
  {
    var project = await _repository.FirstOrDefaultAsync(new GetProjectSpec(request.ProjectId, false), cancellationToken);
    if (project is null)
      return Result.NotFound();

    project.Update(request.Description!);

    await _repository.UpdateAsync(project, cancellationToken);
    await _repository.SaveChangesAsync(cancellationToken);

    return Result.Success(project.Id.ToString());
  }
}
