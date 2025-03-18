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
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IReadRepository<FooterAddress> _readRepository;

        public GetFooterAddressByIdQueryHandler(IReadRepository<FooterAddress> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _readRepository.GetByIdAsync(request.Id, false);
            return new GetFooterAddressByIdQueryResult
            {
                Id = values.Id,
                Address = values.Address,
                FooterDescription = values.FooterDescription,
                Mail = values.Mail,
                Phone = values.Phone
            };
        }
    }
}
