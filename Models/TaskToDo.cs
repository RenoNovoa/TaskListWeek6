using CapstonTask.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapstonTask.Models
{
    public class TaskToDo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "You need to add a Description!")]
        [StringLength(5000, MinimumLength = 2, ErrorMessage = "Description Must Be Between 10-50 characters.")]
        public string Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

       
        public ApplicationUser User { get; set; }
    }
}
