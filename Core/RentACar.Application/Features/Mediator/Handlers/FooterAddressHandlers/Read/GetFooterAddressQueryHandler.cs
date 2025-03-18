using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.FooterAddressQueries;
using RentACar.Application.Features.Mediator.Results.FooterAddressResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.FooterAddressHandlers.Read
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, IQueryable<GetFooterAddressQueryResult>>
    {
        private readonly IReadRepository<FooterAddress> _readRepository;

        public GetFooterAddressQueryHandler(IReadRepository<FooterAddress> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IQueryable<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = _readRepository.GetAll(false).Select(x => new GetFooterAddressQueryResult
            {
                Id = x.Id,
                FooterDescription = x.FooterDescription,
                Address = x.Address,
                Mail = x.Mail,
                Phone = x.Phone
            });
            return await Task.FromResult(values);
        }
    }
}
