using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SP.Core.viewModel;
using Sp.Service.Dtos;
namespace SP.Core.Service
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<PostViewModel, PostDto>();
        }
    }
}
