using EventSourcing.Api.Request;
using EventSourcing.Api.Response;
using EventSourcing.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator mediator;

        public PostController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewPost([FromBody] CreatePostRequest request)
        {
            var command = new CreatePost(request.Content);

            var result = await mediator.Send(command, CancellationToken.None);

            return this.Ok(new PostResponse
            {
                Post = result
            });
        }
    }
}
