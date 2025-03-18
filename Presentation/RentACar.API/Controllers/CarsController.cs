using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Features.CQRS.Handlers.CarHandlers.Read;
using RentACar.Application.Features.CQRS.Handlers.CarHandlers.Write;
using RentACar.Application.Features.CQRS.Queries.CarQueries;
using RentACar.Application.Features.Mediator.Queries.CarQueries;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly IMediator _mediator;
        public CarsController(GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, IMediator mediator)
        {
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            var values = _getCarQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetCarWithBrand")]
        public IActionResult GetCarWithBrand()
        {
            var values = _getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetCarWithBrandAndPricing")]
        public async Task<IActionResult> GetCarWithBrandAndPricing()
        {
            var values = await _mediator.Send(new GetCarsWithBrandAndPricingQuery());
            return Ok(values);
        }

        [HttpGet("GetLast5Cars")]
        public async Task<IActionResult> GetLast5Cars()
        {
            var values = await _mediator.Send(new GetLast5CarsQuery());
            return Ok(values);
        }

        [HttpGet("GetBrandsWithCarCount")]
        public async Task<IActionResult> GetBrandsWithCarCount()
        {
            var values = await _mediator.Send(new GetBrandsByCarCountQuery());
            return Ok(values);
        }

        [HttpGet("GetCarByIdWithBrand/{id}")]
        public async Task<IActionResult> GetCarByIdWithBrand(int id)
        {
            var values = await _mediator.Send(new GetCarByIdWithBrandQuery(id));
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var values = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok();
        }
    }
}
