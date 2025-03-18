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
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IWriteRepository<Blog> _writeRepository;

        public CreateBlogCommandHandler(IWriteRepository<Blog> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _writeRepository.AddAsync(new()
            {
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId,
                CoverImgUrl = request.CoverImgUrl,
                Title = request.Title,
                Description = request.Description,
                CreatedDate = DateTime.Parse(DateTime.Now.ToString())
            });
            await _writeRepository.SaveAsync();
        }
    }
}
