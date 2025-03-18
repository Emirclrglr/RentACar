using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Features.Mediator.Commands.CarFeatureCommands;
using RentACar.Application.Features.Mediator.Queries.CarFeatureQueries;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarFeaturesById(int id)
        {
            var value = await _mediator.Send(new GetCarFeatureByIdWithRelationsQuery(id));
            return Ok(value);
        }

        [HttpGet]
        public IActionResult GetCarFeatures()
        {
            var values = _mediator.Send(new GetCarFeatureQuery());
            return Ok(values);
        }

        [HttpGet("ChangeCarFeatureIsAvailableToTrue/{id}")]
        public async Task<IActionResult> ChangeCarFeatureIsAvailableToTrue(int id)
        {
            await _mediator.Send(new UpdateCarFeatureIsAvailableToTrueCommand(id));
            return Ok();
        }

        [HttpGet("ChangeCarFeatureIsAvailableToFalse/{id}")]
        public async Task<IActionResult> ChangeCarFeatureIsAvailableToFalse(int id)
        {
            await _mediator.Send(new UpdateCarFeatureIsAvailableToFalseCommand(id));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCarId(int carId)
        {
            await _mediator.Send(new CreateCarFeatureByCarCommand());
            return Ok();
        }


    }
}
