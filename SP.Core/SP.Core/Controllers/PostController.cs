using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sp.Service;
using Sp.Service.Dtos;
using SP.Core.viewModel;
using AutoMapper;
namespace SP.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : SpBaseController
    {
        private readonly IPostService postService;
        private readonly IMapper mapper;
        public PostController(IPostService _postService, IMapper _mapper)
        {
            postService = _postService;
            mapper = _mapper;
        }
        [Authorize(Policy = "allUser")]
        [HttpPost]
        public  async Task <IActionResult> Create(PostViewModel viewModel)
        {
            var psotDto = mapper.Map<PostDto>(viewModel);
            var result= await postService.CreatePostAsync(psotDto);
            return await this.ResponseAsync(result);
        }
    }
}