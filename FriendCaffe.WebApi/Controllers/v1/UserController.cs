
using AutoMapper;
using MediatR;

namespace FriendCaffe.WebApi.Controllers.v1;

public class UserController : ApiController
{
    public UserController(IMapper mapper, ISender sender) : base(mapper, sender)
    {
    }
}