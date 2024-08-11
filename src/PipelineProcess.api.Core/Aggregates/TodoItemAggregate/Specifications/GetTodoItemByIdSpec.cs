using Ardalis.Specification;
using PipelineProcess.api.Core.Records;

namespace PipelineProcess.api.Core.Aggregates.TodoItemAggregate.Specifications;

public class GetTodoItemByIdSpec : Specification<TodoItem, GetTodoItemDto>
{
  public GetTodoItemByIdSpec(string id , bool AsReadOnly = true)
  {
    Query.AsTracking(AsReadOnly);
    Query.Select(x => new GetTodoItemDto(
      x.Title,
      x.Description,
      x.CreatedAt
    ));
  }
}
