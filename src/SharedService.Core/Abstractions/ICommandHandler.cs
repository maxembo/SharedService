using CSharpFunctionalExtensions;
using SharedService.SharedKernel;

namespace SharedService.Core.Abstractions;

public interface ICommandHandler<TResponse, in TCommand>
    where TCommand : ICommand
{
    Task<Result<TResponse, Errors>> Handle(TCommand command, CancellationToken cancellationToken = default);
}

public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    Task<UnitResult<Error>> Handle(TCommand request, CancellationToken cancellationToken = default);
}