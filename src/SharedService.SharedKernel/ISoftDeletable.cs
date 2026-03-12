namespace SharedService.SharedKernel;

public interface ISoftDeletable
{
    bool IsActive { get; }

    DateTime? DeletedAt { get; }

    void MarkAsDelete();
}