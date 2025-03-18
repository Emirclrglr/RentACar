using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Queries.CarBookingQueries;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBookingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarBookingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarBookingsByLocation(int id)
        {
            var values = await _mediator.Send(new GetCarBookingQuery(id));
            return Ok(values);
        }

        [HttpGet("GetCarBookingsByLocationWithRelations/{id}")]
        public async Task<IActionResult> GetCarBookingsByLocationWithRelations(int id)
        {
            var values = await _mediator.Send(new GetCarBookingWithCarNameAndBrandNameQuery(id));
            return Ok(values);
        }

        [HttpGet("GetCarBookingsLocationWithCarCount")]
        public async Task<IActionResult> GetCarBookingsLocationWithCarCount()
        {
            var values = await _mediator.Send(new GetCarBookingsLocationWithCarCountQuery());
            return Ok(values);
        }
    }
}
