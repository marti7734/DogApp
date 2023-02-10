﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }

        
        public string BookName { get; set; }
        [Display(Name = "Name")]
        
        public string Author { get; set; }
        [Display(Name = "Author")]
      
        public string Genre { get; set; }
        [Display(Name = "Genre")]
       
        public string Picture { get; set; }
        [Display(Name = "Book Picture")]
       
        public DateTime YearOfPublication { get; set; }
        [Display(Name = "Year of publication")]
        
        public double Price { get; set; }
        [Display(Name = "Price")]
    }
}