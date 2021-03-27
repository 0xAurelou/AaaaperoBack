using AutoMapper;
using DTO;
using Models;
using BackEndAaaapero.Models;

namespace BackEndAaaapero.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //<source class, destination class>
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
        }
    }
}