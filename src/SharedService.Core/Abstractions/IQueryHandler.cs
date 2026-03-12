using CSharpFunctionalExtensions;
using SharedService.SharedKernel;

namespace SharedService.Core.Abstractions;

public interface IQueryHandler<TResponse, in TQuery>
    where TQuery : IQuery
{
    Task<Result<TResponse, Errors>> Handle(TQuery query, CancellationToken cancellationToken);
}

public interface IQueryHandler<TResponse>
{
    Task<TResponse> Handle(CancellationToken cancellationToken);
}