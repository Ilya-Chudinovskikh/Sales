using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataLayer.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string IsbnCode { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
