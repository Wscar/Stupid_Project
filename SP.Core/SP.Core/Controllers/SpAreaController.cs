﻿using System;
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
    public class SpAreaController : SpBaseController
    {
        private readonly IAreaService areaService;
        public SpAreaController(IAreaService _areaService)
        {
            areaService = _areaService;
        }
        [Authorize(Policy = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateArea(AreaDto dto)
        {
            var result = await areaService.CreateAreaAsync(dto);
            return Ok(result);
        }
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await areaService.GetAreasAsync();
            return Ok(result);
        }

    }
}