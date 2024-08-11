using PipelineProcess.api.Core.Aggregates;
using PipelineProcess.api.Core.Aggregates.ProjectAggregate;
using PipelineProcess.api.Core.Aggregates.TodoItemAggregate;
using PipelineProcess.api.Core.Aggregates.TodoItemAggregate.Enums;

namespace PipelineProcess.api.Core.SharedEntities;

public class ProjectTodoItemEntity
  : BaseEntity<Guid>
{
  public StatusEnum Status { get; private set; }
  public AdminAcceptEnum AdminAcceptStatus { get; private set; }
  
  public void SetStatus(StatusEnum statusEnum)
    => this.Status = statusEnum;
  
  public void SetAdminChangeStatus(AdminAcceptEnum statusEnum)
    => this.AdminAcceptStatus = statusEnum;

  public ProjectTodoItemEntity(StatusEnum status, AdminAcceptEnum adminAcceptStatus)
  {
    Id = Guid.NewGuid();
    CreatedAt = DateTime.Now;
    IsRemoved = false;
    
    Status = status;
    AdminAcceptStatus = adminAcceptStatus;
  }
  public Guid? TodoItemId { get; private set; }
  public TodoItem? TodoItem { get; private set; }
  
  public Guid? ProjectId { get; private set; }
  public Project? Project { get; private set; }
}
