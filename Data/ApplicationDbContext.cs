using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using LibApp.Models;

namespace LibApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Customer>().HasData(

                new Customer
                {
                    Id = 1,
                    Name = "Jan Skoczek",
                    Birthdate = new DateTime(1999, 1, 1),
                    HasNewsletterSubscribed = false,
                    MembershipTypeId = 1
                },
                new Customer
                {
                    Id = 2,
                    Name = "Robert Kubica",
                    Birthdate = new DateTime(2000, 2, 2),
                    HasNewsletterSubscribed = false,
                    MembershipTypeId = 1
                },
                new Customer
                {
                    Id = 3,
                    Name = "Dawid Dzięcioł",
                    Birthdate = new DateTime(2003, 3, 3),
                    HasNewsletterSubscribed = false,
                    MembershipTypeId = 1
                }
                );
        }
    }
}
