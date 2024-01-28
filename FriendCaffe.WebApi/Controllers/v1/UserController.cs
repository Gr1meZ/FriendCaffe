using AutoMapper;
using MediatR;

namespace FriendCaffe.WebApi.Controllers.v1;

public class UserController(IMapper mapper, IMediator mediator) : ApiController(mapper, mediator)
{
    
}