using System;
using System.ComponentModel.DataAnnotations;

namespace ToReadList.Models
{
    public class ToReadItem
    {
        public Guid Id { get; set; }
        public bool IsDone { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime? DueAt { get; set; }
        
        public string UserId { get; set; }
    }
}