using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales.DataLayer.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        [Required]
        public PromoCode PromoCode { get; set; }
        public List<Book> OrderedBooks { get; set; }
        [Required]
        public double TotalSum { get; set; }
    }
}
