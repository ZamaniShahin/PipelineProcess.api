using Ardalis.Result;
using Ardalis.SharedKernel;
using Tracking.api.Core.Aggregates.ProjectAggregate;
using Tracking.api.Core.Aggregates.ProjectAggregate.Specifications;
using Tracking.api.Core.Records.ProjectDtos;

namespace Tracking.api.UseCases.Services.Projects.Queries;

public class GetAllProjectsQuery : IQuery<Result<List<GetProjectRecord>>>
{
  
}

public class GetAllProjectsQueryHandler(IReadRepository<Project> repository)
  : IQueryHandler<GetAllProjectsQuery, Result<List<GetProjectRecord>>>
{
  private readonly IReadRepository<Project> _repository = repository;
  public async Task<Result<List<GetProjectRecord>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
  {
    var projects = await _repository.ListAsync(new GetProjectsSpec(), cancellationToken);

    return Result.Success(projects);
  }
}
