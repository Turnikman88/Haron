using AutoMapper;
using Haron.Application.Core.Identity.Users.Models;
using Haron.Domain.Core.Entities;

namespace Haron.Application.Core.Identity.Users.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterModel, User>()
                .ReverseMap();
        }
    }
}