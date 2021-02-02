using System.Data;
using Authentication.API.Entities;
using Authentication.API.Models;
using AutoMapper;

namespace Authentication.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
        }
    }
}