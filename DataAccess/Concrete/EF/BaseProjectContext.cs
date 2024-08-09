using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class BaseProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=TravelDB;Trusted_Connection = true;TrustServerCertificate = true");
        }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<AboutUs> AboutUss { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<TermAndCondition> TermAndConditions {  get; set; } 
     }
}
