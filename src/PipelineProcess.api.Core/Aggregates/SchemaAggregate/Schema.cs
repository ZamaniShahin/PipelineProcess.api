using Ardalis.SharedKernel;
using PipelineProcess.api.Core.Aggregates.ProjectAggregate;

namespace PipelineProcess.api.Core.Aggregates.SchemaAggregate;

public class Schema
    : BaseEntity<Guid>, IAggregateRoot
{
  public Schema(string title, string? description, uint count)
  {
    Id = Guid.NewGuid();
    Title = title;
    Description = description;
    Count = count;
  }

  public void Update(string title, string? description)
  {
    Title = title;
    Description = description;
    this.Modified();
  }
  public string Title { get; private set; }
  public string? Description { get; private set; }
  public uint Count { get; private set; }
  
  private List<Project> _projects = [];
  public IEnumerable<Project> Projects => _projects.AsEnumerable();


}
