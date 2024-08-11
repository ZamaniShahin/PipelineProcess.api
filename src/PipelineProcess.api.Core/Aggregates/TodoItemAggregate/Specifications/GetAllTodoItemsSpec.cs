using Ardalis.Specification;
using PipelineProcess.api.Core.Records;

namespace PipelineProcess.api.Core.Aggregates.TodoItemAggregate.Specifications;

public class GetAllTodoItemsSpec : Specification<TodoItem, GetTodoItemDto>
{
  public GetAllTodoItemsSpec(bool AsReadOnly = true)
  {
    Query.AsTracking();

    Query.Select(item => new GetTodoItemDto(
      item.Title,
      item.Description,
      item.CreatedAt));
  }
}
