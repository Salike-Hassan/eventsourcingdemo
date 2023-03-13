using EventSourcing.Api.Request;
using EventSourcing.Api.Response;
using EventSourcing.Application.Commands;
using EventSourcing.Core.Dispatchers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        // private readonly IMediator mediator;
        private readonly ICommandDispatcher commandDispatcher;

        public PostController(ICommandDispatcher commandDispatcher)
        {
            // this.mediator = mediator;
            this.commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewPost([FromBody] CreatePostCommand command)
        {
            var id = Guid.NewGuid();
            try
            {
                command.Id = id;

                await commandDispatcher.SendAsync(command);

                return this.Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
            //var command = new CreatePost(request.Content);

            //var result = await mediator.Send(command, CancellationToken.None);

            //return this.Ok(new PostResponse
            //{
            //    Post = result
            //});
        }
    }
}
