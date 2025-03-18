using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Commands.AuthorCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.AuthorHandlers.Write
{
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand>
    {
        private readonly IReadRepository<Author> _readRepository;
        private readonly IWriteRepository<Author> _writeRepository;

        public RemoveAuthorCommandHandler(IWriteRepository<Author> writeRepository, IReadRepository<Author> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _readRepository.GetByIdAsync(request.Id);
            _writeRepository.Remove(author);
            await _writeRepository.SaveAsync();
        }
    }
}
