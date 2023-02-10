using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name ="Name")]
        public string BookName { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name ="Author")]
        public string Author { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name ="Genre")]
        public string Genre { get; set; }

        [Display(Name ="Book Picture")]
        public string Picture { get; set; }

        [Display(Name = "Year of publication")]
        public DateTime YearOfPublication { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }
    }
}
