using AutoMapper;
using FriendCaffe.Application.Authentication.Login;
using FriendCaffe.Application.Authentication.Register;
using FriendCaffe.WebApi.Dto.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FriendCaffe.WebApi.Controllers.v1;

public class AuthenticationController(IMapper mapper, IMediator mediator) : ApiController(mapper, mediator)
{
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = Mapper.Map<RegisterCommand>(request);
        var authResult = await Mediator.Send(command);

        var response = Mapper.Map<AuthenticationResponse>(authResult);

        return Ok(response);
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var query = Mapper.Map<LoginQuery>(request);
        var authResult = await Mediator.Send(query);

        var response = Mapper.Map<AuthenticationResponse>(authResult);

        return Ok(response);
    }
}