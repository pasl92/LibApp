using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Models
{
    public class Book
    {
        public int Id { get; set; }
		[Required(ErrorMessage = "Please enter name")]
		[StringLength(255)]
		public string Name { get; set; }
		[Required(ErrorMessage = "Please enter author name")]
		[StringLength(255)]
		public string AuthorName { get; set; }
		public Genre Genre { get; set; }
		[Required(ErrorMessage = "Please select Genre")]
		public byte GenreId { get; set; }
		public DateTime DateAdded { get; set; }
		[Required(ErrorMessage = "Please enter data")]
		public DateTime ReleaseDate { get; set; }
		[Range(1,20)]
		[Required(ErrorMessage = "Please enter number")]
		public int NumberInStock { get; set; }
		public int NumberAvailable { get; set; }
	}
      
}
