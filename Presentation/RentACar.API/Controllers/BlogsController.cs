using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.BlogCommands;
using RentACar.Application.Features.Mediator.Queries.BlogQueries;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var values = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(values);
        }

        [HttpGet("GetLast3BlogsWithAuthor")]
        public async Task<IActionResult> GetLast3BlogsWithAuthor()
        {
            var values = await _mediator.Send(new GetLast3BlogWithAuthorQuery());
            return Ok(values);
        }

        [HttpGet("GetAllBlogsWithAuthor")]
        public async Task<IActionResult> GetAllBlogsWithAuthor()
        {
            var values = await _mediator.Send(new GetAllBlogsWithAuthorsQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogDetailsWithAuthorDetails/{id}")]
        public async Task<IActionResult> GetBlogDetailsWithAuthorDetails(int id)
        {
            var values = await _mediator.Send(new GetBlogByIdWithAuthorQuery(id));
            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok();
        }
    }
}
