﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaconsaleWebApp.Models
{
    public class MovieApplicationContext : DbContext
    {
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base(options)
        {
            //leave blank
        }
        public DbSet<ApplicationResponse> responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                    new Category { CategoryId=1, CategoryName= "Action / Adventure" },
                    new Category { CategoryId = 2, CategoryName = "Comedy" },
                    new Category { CategoryId = 3, CategoryName = "Drama" },
                    new Category { CategoryId = 4, CategoryName = "Family" },
                    new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                    new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                    new Category { CategoryId = 7, CategoryName = "Television" },
                    new Category { CategoryId = 8, CategoryName = "VHS" }

                );
            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    AppID = 1,
                    CategoryId = 1,
                    Title = "Avengers, The",
                    Year = 2012,
                    Director = "Joss Whedon",
                    Rating = "PG-13",
                  

                },
                new ApplicationResponse
                {
                    AppID = 2,
                    CategoryId = 1,
                    Title = "Batman",
                    Year = 1989,
                    Director = "Tim Burton",
                    Rating = "PG-13",
                },
                new ApplicationResponse
                {
                    AppID = 3,
                    CategoryId = 1,
                    Title = "Dark Knight, The",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                }
                );
        }
    }

}
