using AutoMapper;
using LibApp.Data;
using LibApp.Dtos;
using LibApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Interfaces;
using LibApp.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksController(ApplicationDbContext context, IMapper mapper, IBookRepository bookRepository)
        {
            _context = context;
            _mapper = mapper;
            _bookRepository = bookRepository;

        }
        // GET /api/books
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _bookRepository.GetBooks()
                .ToList()
                .Select(_mapper.Map<Book, BookDto>);

            return Ok(books);
        }

        // GET /api/books/{id}
        [HttpGet("{id}", Name = "GetBooks")]
        public async Task<IActionResult> GetBooks(int id)
        {
            Console.WriteLine("Request beginning");
            var book = await _context.Books.SingleOrDefaultAsync(c => c.Id == id);
            await Task.Delay(2000);
            if (book == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            Console.WriteLine("Request end");
            return Ok(_mapper.Map<BookDto>(book));
        }

        // POST /
        [HttpPost]
        public IActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var book = _mapper.Map<Book>(bookDto);
            _bookRepository.AddBook(book);
            _bookRepository.Save();
            bookDto.Id = book.Id;

            return CreatedAtRoute(nameof(GetBooks), new { id = bookDto.Id }, bookDto);
        }

        // PUT /api/customers
        [HttpPut("{id}")]
        public void UpdateBook(int id, BookDto bookDt)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

            var bookInDb = _context.Books.SingleOrDefault(c => c.Id == id);
            if (bookInDb == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            _mapper.Map(bookDt, bookInDb);
            _context.SaveChanges();
        }

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
    }
}