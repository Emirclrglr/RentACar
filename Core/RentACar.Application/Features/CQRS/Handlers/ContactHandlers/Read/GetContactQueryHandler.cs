using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Results.ContactResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.ContactHandlers.Read
{
    public class GetContactQueryHandler
    {
        private readonly IReadRepository<Contact> _readRepository;

        public GetContactQueryHandler(IReadRepository<Contact> readRepository)
        {
            _readRepository = readRepository;
        }

        public IQueryable<GetContactQueryResult> Handle()
        {
            var values = _readRepository.GetAll(false);
            return values.Select(x => new GetContactQueryResult
            {
                Id = x.Id,
                Email = x.Email,
                MessageContent = x.MessageContent,
                Name = x.Name,
                SendDate = x.SendDate,
                Subject = x.Subject
            });
        }
    }
}
