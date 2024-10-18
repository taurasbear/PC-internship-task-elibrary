using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCElibrary.Server.Controllers.DTOs;
using PCElibrary.Server.Repositories.Entities;
using PCElibrary.Server.Services.Interfaces;

namespace PCElibrary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            IEnumerable<BookDTO> books = await this.bookService.GetAllBooksAsync();

            return this.Ok(books);
        }
    }
}
