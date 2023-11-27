using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veturilo.API.Attributes;
using Veturilo.API.Dto;
using Veturilo.API.Extensions;
using Veturilo.Application.Exceptions;
using Veturilo.Application.Services;

namespace Veturilo.API.Controllers
{
    [VeturiloV1Route]
    [ApiController]
    [Authorize]
    public class RentController : ControllerBase
    {
        private IRentService rentService;
        private readonly IMapper mapper;

        public RentController(IRentService rentService, IMapper mapper)
        {
            this.rentService = rentService;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult RentBike(RentBikeDto rentBikeDto)
        {
            try
            {
                var rent = rentService.RentBike(User.GetUserId(), rentBikeDto.BikeId, rentBikeDto.StationId);
                return Ok(new { Message = "Success", RentId = rent.Id });
            }
            catch (ItemNotExistsException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetRents()
        {
            var rents = rentService.GetUserRents(User.GetUserId());
            return Ok(mapper.Map<List<RentDto>>(rents));
        }

        [HttpPost("finish")]
        public IActionResult FinishRentBike(FinishRentBikeDto finishRentBikeDto)
        {
            try
            {
                var rent = rentService.FinishRentBike(User.GetUserId(), finishRentBikeDto.RentId, finishRentBikeDto.StationId);
                return Ok(new { Message = "Success", RentId = rent.Id });
            }
            catch (ItemNotExistsException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
