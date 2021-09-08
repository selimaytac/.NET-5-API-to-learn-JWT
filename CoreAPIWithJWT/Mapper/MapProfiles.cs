using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreAPIWithJWT.IdentityAuth;
using CoreAPIWithJWT.Models.Response;

namespace CoreAPIWithJWT.Mapper
{
    public class MapProfiles : Profile
    {
        public MapProfiles()
        {
            CreateMap<ApplicationUser, UserResponseModel>().ReverseMap();
        }
    }
}
