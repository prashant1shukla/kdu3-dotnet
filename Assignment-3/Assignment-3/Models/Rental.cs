﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_3.Models
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }

        // Define the foreign key for the Movie entity
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        // Define the foreign key for the Customer entity
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime RentalDate { get; set; }
        // Other properties related to rental
    }
}