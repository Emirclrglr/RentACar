using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Commands.CommentCommands;
using RentACar.Application.IRepositories.ICommentRepository;

namespace RentACar.Application.Features.Mediator.Handlers.CommentHandlers.Write
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly ICommentWriteRepository _commentWriteRepository;

        public CreateCommentCommandHandler(ICommentWriteRepository commentWriteRepository)
        {
            _commentWriteRepository = commentWriteRepository;
        }

        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            await _commentWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                MessageContent = request.MessageContent,
                CreatedDate = DateTime.Parse(DateTime.Now.ToString()),
                BlogId = request.BlogId
            });
            await _commentWriteRepository.SaveAsync();
        }
    }
}
