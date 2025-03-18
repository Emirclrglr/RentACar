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
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IWriteRepository<Author> _writeRepository;
        private readonly IReadRepository<Author> _readRepository;

        public UpdateAuthorCommandHandler(IReadRepository<Author> readRepository, IWriteRepository<Author> writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _readRepository.GetByIdAsync(request.Id);
            author.Name = request.Name;
            author.Description = request.Description;
            author.ImageUrl = request.ImageUrl;
            await _writeRepository.SaveAsync();
        }
    }
}
