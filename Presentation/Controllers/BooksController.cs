﻿using Application.Commands;
using Application.Queries;
using Application.Queries.Books;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<BookResponse>>> GetAllBooks()
        {
            var books = await _mediator.Send(new GetAllBooksQuery());
            return Ok(books);
        }

        [Authorize]
        [HttpGet("search")]
        public async Task<ActionResult<List<BookResponse>>> SearchBooks([FromQuery] string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return BadRequest("Title parameter is required.");

            var books = await _mediator.Send(new SearchBooksQuery { Title = title });
            return Ok(books);
        }

        [Authorize(Roles = "Librarian")]
        [HttpPost]
        public async Task<ActionResult<int>> AddBook([FromBody] CreateBookCommand command)
        {
            var bookId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllBooks), new { id = bookId }, bookId);
        }

        [Authorize(Roles = "Librarian")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditBook(int id, [FromBody] EditBookCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Book ID mismatch.");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<BookResponse>> GetBookById(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery { Id = id });
            return Ok(book);
        }

        [Authorize(Roles = "Librarian")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await _mediator.Send(new DeleteBookCommand { Id = id });
            return NoContent();
        }
    }
}