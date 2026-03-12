using CSharpFunctionalExtensions;
using SharedService.SharedKernel;

namespace SharedService.Core.Database;

public interface ITransactionManager
{
    Task<Result<ITransactionScope, Error>> BeginTransactionAsync(CancellationToken cancellationToken = default);

    Task<UnitResult<Error>> SaveChangeAsync(CancellationToken cancellationToken = default);
}