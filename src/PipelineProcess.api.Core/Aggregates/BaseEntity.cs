using Ardalis.SharedKernel;

namespace PipelineProcess.api.Core.Aggregates;

public abstract class BaseEntity<TId>: EntityBase<TId>
  where TId : struct, IEquatable<TId>
{
  public DateTime CreatedAt { get; protected set; }
  public bool IsRemoved { get; protected set; }
  public DateTime? ModifiedAt { get; protected set; }
  protected void Modified()
    => this.ModifiedAt = DateTime.Now;

  public BaseEntity()
  {
    CreatedAt = DateTime.Now;
    IsRemoved = false;
  }
}
