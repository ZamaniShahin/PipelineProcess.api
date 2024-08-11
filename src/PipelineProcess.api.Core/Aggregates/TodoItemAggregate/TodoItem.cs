using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using PipelineProcess.api.Core.Aggregates.ProjectAggregate;
using PipelineProcess.api.Core.Aggregates.TodoItemAggregate.Enums;
using PipelineProcess.api.Core.SharedEntities;

namespace PipelineProcess.api.Core.Aggregates.TodoItemAggregate;

public class TodoItem
  : BaseEntity<Guid>, IAggregateRoot
{
  public string Title { get; private set; }
  public string Description { get; private set; }


  public TodoItem(string title, string description)
  {
    Id = Guid.NewGuid();
    CreatedAt = DateTime.Now;
    IsRemoved = false;
    
    
    Title = Guard.Against.NullOrEmpty(title, nameof(title));
    Description = Guard.Against.NullOrEmpty(description, nameof(description));
  }

  public void Update(string title, string description)
  {
    Title = Guard.Against.NullOrEmpty(title, nameof(title));
    Description = Guard.Against.NullOrEmpty(description, nameof(description));
  }

  private List<ProjectTodoItemEntity> _projectTodoItems = [];
  public IEnumerable<ProjectTodoItemEntity> ProjectTodoItems => _projectTodoItems.AsEnumerable();
  

}
