using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.CarResults;

namespace RentACar.Application.Features.Mediator.Queries.CarQueries
{
    public class GetCarByIdWithBrandQuery:IRequest<GetCarByIdWithBrandQueryResult>
    {
        public int Id { get; set; }

        public GetCarByIdWithBrandQuery(int id)
        {
            Id = id;
        }
    }
}
