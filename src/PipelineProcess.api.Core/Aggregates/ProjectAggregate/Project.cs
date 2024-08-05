using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using PipelineProcess.api.Core.Aggregates.SchemaAggregate;
using PipelineProcess.api.Core.Aggregates.TodoItemAggregate;

namespace PipelineProcess.api.Core.Aggregates.ProjectAggregate;

public class Project
  : BaseEntity<Guid>, IAggregateRoot
{
  public string Description { get; private set; }

  public Project(string description, Guid? schemaId)
  {
    Id = Guid.NewGuid();
    CreatedAt = DateTime.Now;
    IsRemoved = false;

    SchemaId = schemaId;
    Description = Guard.Against.NullOrEmpty(description, nameof(description));
  }
  public void Update(string description)
  {
    Description = Guard.Against.NullOrEmpty(description, nameof(description));
  }

  // private List<Schema> _schemas = [];
  // public IEnumerable<Schema> Schemas => _schemas.AsReadOnly();
  
  public Guid? SchemaId { get; private set; }
  public Schema? Schema { get; private set; }
  
  private List<TodoItem> _todoItems = [];
  public IEnumerable<TodoItem> TodoItems => _todoItems.AsReadOnly();

  
}
