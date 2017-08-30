using MvcCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcCodeFirst.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext() : base("StudentDbContext")
        {

        }
        public DbSet<Student> students { get; set; }
    }
}