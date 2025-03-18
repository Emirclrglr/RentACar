using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.CommentCommands;
using RentACar.Application.Features.Mediator.Queries.CommentQueries;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var values = await _mediator.Send(new GetCommentQuery());
            return Ok(values);
        }

        [HttpGet("GetCommentCountByBlogId/{id}")]
        public async Task<IActionResult> GetCommentCountByBlogId(int id)
        {
            var count = await _mediator.Send(new GetCommentCountQuery(id));
            return Ok(count);
        }

        [HttpGet("GetCommentsByBlogId/{id}")]
        public async Task<IActionResult> GetCommentsByBlogId(int id)
        {
            var values = await _mediator.Send(new GetCommentByBlogIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
