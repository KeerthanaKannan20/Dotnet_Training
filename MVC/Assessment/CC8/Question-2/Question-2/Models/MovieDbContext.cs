using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Question_2.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext() : base("connectstr") { }

        public DbSet<Movie> Movies { get; set; }
    }
}