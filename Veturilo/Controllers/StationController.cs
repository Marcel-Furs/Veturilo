﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veturilo.API.Attributes;
using Veturilo.Application.Services;

namespace Veturilo.API.Controllers
{
    [VeturiloV1Route]
    [ApiController]
    [Authorize]
    public class StationController : ControllerBase
    {
        private readonly IRentService rentService;

        public StationController(IRentService rentService)
        {
            this.rentService = rentService;
        }

        [HttpGet]
        public IActionResult GetAllStations()
        {
            return Ok(rentService.GetAllStations());
        }

        [HttpGet("{id}")]
        public IActionResult GetStation(int id)
        {
            return Ok(rentService.GetStation(id));
        }

        [HttpGet("{id}/bikes")]
        public IActionResult GetBikesFromStation(int id)
        {
            return Ok(rentService.GetBikesFromStation(id));
        }
    }
}
