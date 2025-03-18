using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Commands.BlogCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.BlogHandlers.Write
{
    public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommand>
    {
        private readonly IReadRepository<Blog> _readRepository;
        private readonly IWriteRepository<Blog> _writeRepository;

        public RemoveBlogCommandHandler(IWriteRepository<Blog> writeRepository, IReadRepository<Blog> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _readRepository.GetByIdAsync(request.Id);
            _writeRepository.Remove(blog);
            await _writeRepository.SaveAsync();
        }
    }
}
