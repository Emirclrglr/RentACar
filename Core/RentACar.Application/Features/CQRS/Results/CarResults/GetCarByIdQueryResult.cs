using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.CQRS.Results.CarResults
{
    public class GetCarByIdQueryResult:BaseEntity
    {
        public string Model { get; set; }
        public string CoverIMG { get; set; }
        public string BigIMG { get; set; }
        public int Kilometer { get; set; }
        public string Transmission { get; set; }
        public byte Seats { get; set; }
        public byte Luggage { get; set; }
        public string FuelType { get; set; }
        public int BrandId { get; set; }
    }
}
