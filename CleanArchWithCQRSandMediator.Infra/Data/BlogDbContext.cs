using CleanArchWithCQRSandMediator.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWithCQRSandMediator.Infra.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
