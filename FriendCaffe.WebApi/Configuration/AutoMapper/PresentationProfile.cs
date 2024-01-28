using AutoMapper;
using FriendCaffe.Application.Authentication;
using FriendCaffe.Application.Authentication.Login;
using FriendCaffe.Application.Authentication.Register;
using FriendCaffe.WebApi.Dto.Authentication;


namespace FriendCaffe.WebApi.Configuration.AutoMapper;

public class PresentationProfile : Profile
{
    public PresentationProfile()
    {
        CreateMap<AuthenticationResult, AuthenticationResponse>();
        CreateMap<LoginRequest, LoginQuery>();
        CreateMap<RegisterRequest, RegisterCommand>();
        

    }
}