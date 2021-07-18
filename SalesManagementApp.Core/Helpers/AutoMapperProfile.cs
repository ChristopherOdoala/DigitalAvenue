using AutoMapper;
using SalesManagementApp.Core.Models;
using SalesManagementApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesManagementApp.Core.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
        }
    }
}
