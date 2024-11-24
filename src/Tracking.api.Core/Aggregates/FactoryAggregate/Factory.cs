using Ardalis.SharedKernel;
using Tracking.api.Core.Aggregates.ProcessAggregate;

namespace Tracking.api.Core.Aggregates.FactoryAggregate;

public class Factory
  : BaseEntity<Guid>, IAggregateRoot
{
  public string Title { get; set; }

  private List<Process> _processes = [];
  public IEnumerable<Process> Processes => _processes.AsEnumerable();

  public Factory(string title)
  {
    Id = Guid.NewGuid();
    Title = title;
  }
}
