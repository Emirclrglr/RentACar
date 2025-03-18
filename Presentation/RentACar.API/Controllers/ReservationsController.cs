using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.ReservationCommands;
using RentACar.Application.Features.Mediator.Queries.ReservationQueries;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            var values = await _mediator.Send(new GetReservationQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(int id)
        {
            var values = await _mediator.Send(new GetReservationByIdQuery(id));
            return Ok(values);
        }

        [HttpGet("GetReservationsWithRelations")]
        public async Task<IActionResult> GetReservationsWithRelations()
        {
            var values = await _mediator.Send(new GetReservationWithRelationsQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReservation(UpdateReservationCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            await _mediator.Send(new DeleteReservationCommand(id));
            return Ok();
        }
    }
}
