using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Queries.AuthorQueries;
using RentACar.Application.Features.Mediator.Queries.BlogQueries;
using RentACar.Application.Features.Mediator.Queries.BrandQueries;
using RentACar.Application.Features.Mediator.Queries.CarPricingQueries;
using RentACar.Application.Features.Mediator.Queries.CarQueries;
using RentACar.Application.Features.Mediator.Queries.LocationQueries;
using RentACar.Application.Features.Mediator.Queries.ServiceQueries;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("CarCount")]
        public async Task<IActionResult> CarCount()
        {
            var count = await _mediator.Send(new GetCarCountQuery());
            return Ok(count);
        }

        [HttpGet("LocationCount")]
        public async Task<IActionResult> LocationCount()
        {
            var count = await _mediator.Send(new GetLocationCountQuery());
            return Ok(count);
        }

        [HttpGet("AuthorCount")]
        public async Task<IActionResult> AuthorCount()
        {
            var count = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(count);
        }

        [HttpGet("BlogCount")]
        public async Task<IActionResult> BlogCount()
        {
            var count = await _mediator.Send(new GetBlogCountQuery());
            return Ok(count);
        }

        [HttpGet("BrandCount")]
        public async Task<IActionResult> BrandCount()
        {
            var count = await _mediator.Send(new GetBrandCountQuery());
            return Ok(count);
        }

        [HttpGet("AverageDailyCarRentalPrice")]
        public async Task<IActionResult> AverageDailyCarRentalPrice()
        {
            var count = await _mediator.Send(new GetAvgDailyCarRentalPriceQuery());
            return Ok(count);
        }

        [HttpGet("AverageHourlyCarRentalPrice")]
        public async Task<IActionResult> AverageHourlyCarRentalPrice()
        {
            var count = await _mediator.Send(new GetAvgHourlyCarRentalPriceQuery());
            return Ok(count);
        }

        [HttpGet("AverageWeeklyCarRentalPrice")]
        public async Task<IActionResult> AverageWeeklyCarRentalPrice()
        {
            var count = await _mediator.Send(new GetAvgWeeklyCarRentalPriceQuery());
            return Ok(count);
        }

        [HttpGet("AutomaticCarCount")]
        public async Task<IActionResult> AutomaticCarCount()
        {
            var count = await _mediator.Send(new GetAutoCarCountQuery());
            return Ok(count);
        }

        [HttpGet("BrandWithTheMostVehicles")]
        public async Task<IActionResult> BrandWithTheMostVehicles()
        {
            var car = await _mediator.Send(new GetBrandWithTheMostVehiclesQuery());
            return Ok(car);
        }


        [HttpGet("VehicleCountWithLessThan1000KmAsync")]
        public async Task<IActionResult> VehicleCountWithLessThan1000KmAsync()
        {
            var count = await _mediator.Send(new GetVehicleCountWithLessThan1000KmQuery());
            return Ok(count);
        }

        [HttpGet("VehicleCountByFuelTypeGasOrDiesel")]
        public async Task<IActionResult> VehicleCountByFuelTypeGasOrDiesel()
        {
            var count = await _mediator.Send(new GetVehicleCountByFuelTypeGasOrDieselQuery());
            return Ok(count);
        }

        [HttpGet("VehicleCountByFuelTypeElectric")]
        public async Task<IActionResult> VehicleCountByFuelTypeElectric()
        {
            var count = await _mediator.Send(new GetVehicleCountByFuelTypeElectricQuery());
            return Ok(count);
        }

        [HttpGet("MostExpensiveVehicle")]
        public async Task<IActionResult> MostExpensiveVehicle()
        {
            var car = await _mediator.Send(new GetMostExpensiveVehicleQuery());
            return Ok(car);
        }

        [HttpGet("CheapestVehicle")]
        public async Task<IActionResult> CheapestVehicle()
        {
            var car = await _mediator.Send(new GetCheapestVehicleQuery());
            return Ok(car);
        }

        [HttpGet("ServiceCount")]
        public async Task<IActionResult> ServiceCount()
        {
            var count = await _mediator.Send(new GetServiceCountQuery());
            return Ok(count);
        }
    }
}
