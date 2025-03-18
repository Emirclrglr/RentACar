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
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IReadRepository<Blog> _readRepository;
        private readonly IWriteRepository<Blog> _writeRepository;

        public UpdateBlogCommandHandler(IWriteRepository<Blog> writeRepository, IReadRepository<Blog> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _readRepository.GetByIdAsync(request.Id);
            blog.Title = request.Title;
            blog.AuthorId = request.AuthorId;
            blog.CoverImgUrl = request.CoverImgUrl;
            blog.CategoryId = request.CategoryId;
            blog.CreatedDate = request.CreatedDate;
            await _writeRepository.SaveAsync();
        }
    }
}
