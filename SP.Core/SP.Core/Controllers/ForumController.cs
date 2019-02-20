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
    public class ForumController : ControllerBase
    {
        private readonly IForumService forumService;
        public ForumController(IForumService _forumService)
        {
            forumService = _forumService;
        }
        [Authorize(Policy = "admin")]
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateForum(ForumDto dto)
        {
            var result= await forumService.CreateForumAsync(dto);
            return Ok(result);
        }
        
        [Authorize(Policy ="admin")]
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateForum(ForumDto dto)
        {
            var result = await forumService.UpdateForumNameAsync(dto);
            return Ok(result);
        }
        public async Task<IActionResult> GetForum(int areaId)
        {
            var result = await forumService.GetForumListAsync(areaId);
            return Ok(result);
        }
    }
}