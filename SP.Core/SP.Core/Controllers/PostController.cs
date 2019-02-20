using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sp.Service;
using Sp.Service.Dtos;
namespace SP.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : SpBaseController
    {
        private readonly IPostService postService;
        public PostController(IPostService _postService)
        {
            postService = _postService;
        }
        [Authorize(Policy = "allUser")]
        [HttpPost]
        public  async Task <IActionResult> Create([FromBody]PostDto dto)
        {
            var result= await postService.CreatePostAsync(dto);
            return Ok(result);
        }
    }
}