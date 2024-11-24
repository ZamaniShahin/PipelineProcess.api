using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Tracking.api.Core.Aggregates.FactoryAggregate;
using Tracking.api.Core.SharedEntities;

namespace Tracking.api.Core.Aggregates.ProcessAggregate;

public class Process
  : BaseEntity<Guid>, IAggregateRoot
{
  public string Title { get; private set; }
  public string Description { get; private set; }


  public Factory? Factory { get;  set; }
  public Guid? FactoryId { get; set; }
  
  public Process(string title, string description)
  {
    Id = Guid.NewGuid();
    
    Title = Guard.Against.NullOrEmpty(title, nameof(title));
    Description = Guard.Against.NullOrEmpty(description, nameof(description));
  }

  public void Update(string title, string description)
  {
    Title = Guard.Against.NullOrEmpty(title, nameof(title));
    Description = Guard.Against.NullOrEmpty(description, nameof(description));
  }

  private List<ProcessSheetEntity> _ProcessSheets = [];
  public IEnumerable<ProcessSheetEntity> ProcessSheets => _ProcessSheets.AsEnumerable();
  

}
