using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Backend.Data.Models
{
    [Table("TodoItem")]
    public class TodoItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { set; get; }
        [Required]
        public bool IsComplete { get; set; }
    }
}
