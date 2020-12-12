using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToReadList.Models;
using Microsoft.AspNetCore.Identity;

namespace ToReadList.Services
{
    public interface IToReadItemService
    {
        Task<ToReadItem[]> GetIncompleteItemsAsync(IdentityUser user);
        Task<bool> AddBookAsync(ToReadItem newBook, IdentityUser user);
        
        Task<bool> MarkDoneAsync(Guid id, IdentityUser user);

    }  
}