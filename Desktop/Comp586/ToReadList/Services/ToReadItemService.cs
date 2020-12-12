using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToReadList.Data;
using ToReadList.Models;
using Microsoft.EntityFrameworkCore;
//using static ToReadList.Controllers.HomeController;
using Microsoft.AspNetCore.Identity;


namespace ToReadList.Services
{
    public class ToReadItemService : IToReadItemService
    {
        private readonly ApplicationDbContext _context;
        public ToReadItemService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ToReadItem[]> GetIncompleteItemsAsync(IdentityUser user)
        {
            return await _context.Books.Where(x => x.IsDone == false && x.UserId == user.Id).ToArrayAsync();
        }
        public async Task<bool> AddBookAsync(ToReadItem newBook, IdentityUser user)
        {
            newBook.Id = Guid.NewGuid();
            newBook.IsDone = false;
            //newBook.DueAt = ; //DateTimeOffset.Now.AddDays(3);
            _context.Books.Add(newBook);
            newBook.UserId = user.Id;
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        public async Task<bool> MarkDoneAsync(Guid id, IdentityUser user)
        {
            var book = await _context.Books.Where(x => x.Id == id  && x.UserId == user.Id).SingleOrDefaultAsync();
            if (book == null) return false;
            book.IsDone = true;
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1; // One entity should have been updated
        }   
    }
}