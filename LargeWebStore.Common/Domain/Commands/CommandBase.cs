using MediatR;

namespace LargeWebStore.Common.Domain.Commands
{
    public class CommandBase<T> : IRequest<T> where T : class
    {
    }
}
