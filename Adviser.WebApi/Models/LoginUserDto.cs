using Adviser.Application.Common.Mapping;
using AutoMapper;
using Adviser.Application.CQRS.Users.Queries.LoginUser;

namespace Adviser.WebApi.Models
{
    public class LoginUserDto : IMapWith<LoginUserQuery>
    {
        public string? Email { get; set; }

        public string? Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginUserDto, LoginUserQuery>()
                .ForMember(userCommand => userCommand.Email,
                    option => option.MapFrom(userDto => userDto.Email))
                .ForMember(userCommand => userCommand.Password,
                    option => option.MapFrom(userDto => userDto.Password));
        }
    }
}
