using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToReadList.Services;
using ToReadList.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ToReadList.Controllers
{
    [Authorize]
    public class ToReadController : Controller
    {
        private readonly IToReadItemService _toreadItemService;
        private readonly UserManager<IdentityUser> _userManager;
        public ToReadController(IToReadItemService toreadItemService, UserManager<IdentityUser> userManager)
            {
            _toreadItemService = toreadItemService;
            _userManager = userManager;
            }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();
            var books = await _toreadItemService.GetIncompleteItemsAsync(currentUser);
            var model = new ToReadViewModel()
            {
                Books = books
            };
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBook(ToReadItem newBook)
        {
        if (!ModelState.IsValid)
        {
        return RedirectToAction("Index");
        }
        //var successful = await _toreadItemService.AddBookAsync(newBook);
        
        var currentUser = await _userManager.GetUserAsync(User);
        if (currentUser == null) return Challenge();
        var successful = await _toreadItemService.AddBookAsync(newBook, currentUser);

        if (!successful)
        {
        return BadRequest(new {error = "Could not add book."});
        }
        return RedirectToAction("Index");
        }


        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
            {
            return RedirectToAction("Index");
            }
            //var successful = await _toreadItemService.MarkDoneAsync(id);
              
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();
            var successful = await _toreadItemService.MarkDoneAsync(id, currentUser);
              
                if (!successful)
                {
                    return BadRequest("Could not mark item as done.");
                }
            return RedirectToAction("Index");
        }

        
        
            //private readonly IToReadItemService _toreadItemService;
            

            // ...
        

    }
}