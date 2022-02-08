using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;

namespace LibApp.Dtos
{
    public class BookDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public byte GenreId { get; set; }
        public GenreTypeDto Genre { get; set; }
    }
}