using Dapper;
using DevOne.Security.Cryptography.BCrypt;
using FluentValidation;
using FriendCaffe.Application.Common;
using FriendCaffe.Application.Configuration.Commands;
using FriendCaffe.Application.Configuration.Data;
using FriendCaffe.Application.Configuration.Queries;
using FriendCaffe.Application.Exceptions;
using FriendCaffe.Domain.Aggregates.User;

namespace FriendCaffe.Application.Authentication.Login;

public class LoginHandler : IQueryHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public LoginHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        
        if (!BCryptHelper.CheckPassword(request.Password, user.Password.Hash))
        {
            throw new ValidationException("Invalid password");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user.Id, user.Email.Value, token);
    }
}