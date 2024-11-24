using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Tracking.api.Core.Aggregates.ProcessAggregate;
using Tracking.api.Core.Aggregates.SchemaAggregate;
using Tracking.api.Core.SharedEntities;

namespace Tracking.api.Core.Aggregates.ProjectAggregate;

public class Project
  : BaseEntity<Guid>, IAggregateRoot
{
  public string Description { get; private set; }

  public Project(string description, Guid? schemaId)
  {
    Id = Guid.NewGuid();

    SchemaId = schemaId;
    Description = Guard.Against.NullOrEmpty(description, nameof(description));
  }
  public void Update(string description)
  {
    Description = Guard.Against.NullOrEmpty(description, nameof(description));
  }

  public Guid? SchemaId { get; private set; }
  public Schema? Schema { get; private set; }
  
  
  private List<ProcessSheetEntity> _projectProcesses = [];
  public IEnumerable<ProcessSheetEntity> ProjectProcesses => _projectProcesses.AsEnumerable();
  
  
}
