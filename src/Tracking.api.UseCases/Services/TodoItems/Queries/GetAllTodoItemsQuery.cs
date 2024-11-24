using Ardalis.Result;
using Ardalis.SharedKernel;
using Tracking.api.Core.Aggregates.ProcessAggregate;
using Tracking.api.Core.Aggregates.ProcessAggregate.Specifications;
using Tracking.api.Core.Records.ProcessDtos;

namespace Tracking.api.UseCases.Services.TodoItems.Queries;

public class GetAllTodoItemsQuery() : IQuery<Result<List<GetProcessDto>>>
{
}

public class GetAllTodoItemsQueryHandler(IReadRepository<Process> repository)
  : IQueryHandler<GetAllTodoItemsQuery, Result<List<GetProcessDto>>>
{
  private readonly IReadRepository<Process> _repository = repository;

  public async Task<Result<List<GetProcessDto>>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
  {
    var todoItem = await _repository.ListAsync(new GetAllProcessesSpec(), cancellationToken);

    return Result<List<GetProcessDto>>.Success(todoItem.Count > 0 ? todoItem : []);
  }
}
