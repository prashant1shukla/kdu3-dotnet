﻿namespace Assignment_3.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public ICollection<Rental> Rentals { get; set; }
    }
}
