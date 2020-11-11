using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Books;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> List()
        {
            return await _mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Details(int id)
        {
            return await _mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create([FromBody] Create.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Edit.Command command, int id)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }


        [HttpDelete("{id}")]
        //Could also use the syntax used in the Details function
        public async Task<ActionResult<Unit>> Delete(Delete.Command command, int id)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }
    }
}