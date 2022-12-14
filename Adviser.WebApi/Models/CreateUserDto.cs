using Adviser.Application.Common.Mapping;
using AutoMapper;
using Adviser.Application.CQRS.Users.Commands.CreateUser;

namespace Adviser.WebApi.Models
{
    public class CreateUserDto : IMapWith<CreateUserCommand>
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>()
                .ForMember(userCommand => userCommand.Name,
                    option => option.MapFrom(userDto => userDto.Name))
                .ForMember(userCommand => userCommand.Email,
                    option => option.MapFrom(userDto => userDto.Email))
                .ForMember(userCommand => userCommand.Password,
                    option => option.MapFrom(userDto => userDto.Password));
        }
    }
}
