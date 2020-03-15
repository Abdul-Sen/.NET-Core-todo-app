using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Data.Models
{
    public class TodoItem
    {
        [Required]
        public string Name { set; get; }
        public long Id { get; set; }
        [Required]
        public bool IsComplete { get; set; }
    }
}
