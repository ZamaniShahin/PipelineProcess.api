using Ardalis.Result;
using Ardalis.SharedKernel;
using PipelineProcess.api.Core.Aggregates.ProcessAggregate;
using PipelineProcess.api.Core.Aggregates.ProcessAggregate.Specifications;
using PipelineProcess.api.Core.Records.ProcessDtos;

namespace PipelineProcess.api.UseCases.Services.TodoItems.Queries;

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
