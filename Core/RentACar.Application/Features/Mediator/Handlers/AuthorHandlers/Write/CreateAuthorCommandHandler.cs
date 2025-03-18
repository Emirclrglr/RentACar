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
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
    {
        private readonly IWriteRepository<Author> _writeRepository;

        public CreateAuthorCommandHandler(IWriteRepository<Author> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            await _writeRepository.AddAsync(new Author()
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl
            });
            await _writeRepository.SaveAsync();
        }
    }
}
