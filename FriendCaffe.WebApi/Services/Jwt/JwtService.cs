using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace FriendCaffe.WebApi.Services.Jwt;

public class JwtService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public JwtService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid ExtractJwt()
    {
        string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        var jwt = authorizationHeader.Split(' ')[1];
        

        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadToken(jwt);
        var jwtToken = (JwtSecurityToken)token;
        var claims = jwtToken.Claims;

        var subject = claims.First(c => c.Type == "sub").Value;
        
        return Guid.Parse(subject);
    }
}