using Tracking.api.Core.Aggregates;
using Tracking.api.Core.Aggregates.ProcessAggregate;
using Tracking.api.Core.Aggregates.ProcessAggregate.Enums;
using Tracking.api.Core.Aggregates.ProjectAggregate;

namespace Tracking.api.Core.SharedEntities;

public class ProcessSheetEntity
  : BaseEntity<Guid>
{
  public StatusEnum Status { get; private set; }
  public AdminAcceptEnum AdminAcceptStatus { get; private set; }
  public DateTime? StatusChangedAt { get; private set; }
  public DateTime? AdminAcceptStatusChangedAt { get; private set; }

  public void SetStatus(StatusEnum statusEnum)
  {
    this.Status = statusEnum;
    StatusChangedAt = DateTime.Now;
  }
  

  public void SetAdminAcceptStatus(AdminAcceptEnum adminAcceptStatus)
  {
    AdminAcceptStatus = adminAcceptStatus;
    AdminAcceptStatusChangedAt = DateTime.Now;
  }

  public ProcessSheetEntity()
  {
    Id = Guid.NewGuid();
  }
  public Guid? TodoItemId { get; private set; }
  public Process? TodoItem { get; private set; }
  
  public Guid? ProjectId { get; private set; }
  public Project? Project { get; private set; }
}
