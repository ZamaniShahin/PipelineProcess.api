using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using PipelineProcess.api.Core.Aggregates.SchemaAggregate;
using PipelineProcess.api.Core.Aggregates.ProcessAggregate;
using PipelineProcess.api.Core.SharedEntities;

namespace PipelineProcess.api.Core.Aggregates.ProjectAggregate;

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
