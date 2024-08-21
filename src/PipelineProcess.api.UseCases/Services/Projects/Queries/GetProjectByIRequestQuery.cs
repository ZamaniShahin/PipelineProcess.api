using Ardalis.Result;
using Ardalis.SharedKernel;
using PipelineProcess.api.Core.Aggregates.ProjectAggregate;
using PipelineProcess.api.Core.Aggregates.ProjectAggregate.Specifications;
using PipelineProcess.api.Core.Records.ProjectDtos;

namespace PipelineProcess.api.UseCases.Services.Projects.Queries;

public class GetProjectByIdQuery(Guid projectId) : IQuery<Result<GetProjectByIdRecord>>
{
  public Guid ProjectId { get; set; } = projectId;
}

public class GetProjectByIdQueryHandler(IReadRepository<Project> repository)
  : IQueryHandler<GetProjectByIdQuery, Result<GetProjectByIdRecord>>
{
  private readonly IReadRepository<Project> _repository = repository;
  public async Task<Result<GetProjectByIdRecord>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
  {
    var projects = await _repository.FirstOrDefaultAsync(new GetAllProjectsSpec(request.ProjectId), cancellationToken);
    return projects is null ? Result<GetProjectByIdRecord>.NotFound() : Result<GetProjectByIdRecord>.Success(projects);
  }
}
