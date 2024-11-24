using Ardalis.Result;
using Ardalis.SharedKernel;
using Tracking.api.Core.Aggregates.ProcessAggregate;
using Tracking.api.Core.Aggregates.ProcessAggregate.Specifications;
using Tracking.api.Core.Records.ProcessDtos;

namespace Tracking.api.UseCases.Services.TodoItems.Queries;

public class GetTodoItemByIdQuery(string id) : IQuery<Result<GetProcessDto>>
{
  public string Id { get; set; } = id;
}

public class GetTodoItemByIdQueryHandler(IReadRepository<Process> repository)
  : IQueryHandler<GetTodoItemByIdQuery, Result<GetProcessDto>>
{
  private readonly IReadRepository<Process> _repository = repository;
  public async Task<Result<GetProcessDto>> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
  {
    var todoItem = await _repository.FirstOrDefaultAsync(new GetProcessByIdSpec(request.Id), cancellationToken);

    if (todoItem is null)
      return Result<GetProcessDto>.NotFound();
    
    return Result<GetProcessDto>.Success(todoItem);
    
  }
}
