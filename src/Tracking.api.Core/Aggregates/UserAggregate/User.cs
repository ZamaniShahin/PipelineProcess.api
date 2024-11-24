namespace Tracking.api.Core.Aggregates.UserAggregate;

public class User : BaseEntity<Guid>
{
  public string Username { get; private set; }
  public string Password { get; private set; }
  

  // private List<UserRole> _processes = [];
  // public IEnumerable<UserRole> Processes => _processes.AsEnumerable();
}
