namespace SharedService.SharedKernel;

public abstract class BaseEntity<TId>
    where TId : notnull
{
    protected BaseEntity(TId id) => Id = id;

    public TId Id { get; private set; }

    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; protected set; } = DateTime.UtcNow;
}