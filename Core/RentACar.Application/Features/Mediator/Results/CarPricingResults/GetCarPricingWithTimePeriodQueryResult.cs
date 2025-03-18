using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Results.CarPricingResults
{
    public class GetCarPricingWithTimePeriodQueryResult
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public string CoverIMG { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal HourlyPrice { get; set; }
        public decimal WeeklyPrice { get; set; }
    }
}
