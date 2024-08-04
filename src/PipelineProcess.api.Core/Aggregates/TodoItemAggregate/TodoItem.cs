using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using PipelineProcess.api.Core.Aggregates.ProjectAggregate;
using PipelineProcess.api.Core.Aggregates.TodoItemAggregate.Enums;

namespace PipelineProcess.api.Core.Aggregates.TodoItemAggregate;

public class TodoItem
  : BaseEntity<Guid>, IAggregateRoot
{
  public string Title { get; private set; }
  public string Description { get; private set; }
  public StatusEnum Status { get; private set; }
  public AdminAcceptEnum AdminAcceptStatus { get; private set; }

  public TodoItem(string title, string description)
  {
    Id = Guid.NewGuid();
    CreatedAt = DateTime.Now;
    IsRemoved = false;
    
    
    Title = Guard.Against.NullOrEmpty(title, nameof(title));
    Description = Guard.Against.NullOrEmpty(description, nameof(description));
  }

  public void SetStatus(StatusEnum statusEnum)
    => this.Status = statusEnum;
  
  public void SetAdminChangeStatus(AdminAcceptEnum statusEnum)
    => this.AdminAcceptStatus = statusEnum;
  
  private List<Project> _projects = [];
  public IEnumerable<Project> Projects => _projects.AsReadOnly();

}
