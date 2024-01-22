using MediatR;

namespace FriendCaffe.Application.Configuration.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{
    
}