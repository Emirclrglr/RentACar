using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Queries.ContactQueries;
using RentACar.Application.Features.CQRS.Results.ContactResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.ContactHandlers.Read
{
    public class GetContactByIdQueryHandler
    {
        private readonly IReadRepository<Contact> _readRepository;

        public GetContactByIdQueryHandler(IReadRepository<Contact> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var values = await _readRepository.GetByIdAsync(query.Id, false);
            return new GetContactByIdQueryResult
            {
                Id = values.Id,
                Email = values.Email,
                MessageContent = values.MessageContent,
                Name = values.Name,
                SendDate = values.SendDate,
                Subject = values.Subject
            };
        }
    }
}
