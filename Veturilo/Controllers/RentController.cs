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

        public RentController(IRentService rentService)
        {
            this.rentService = rentService;
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
    }
}
