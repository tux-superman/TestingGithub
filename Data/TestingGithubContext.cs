using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestingGithub.Models
{
    public class TestingGithubContext : DbContext
    {
        public TestingGithubContext (DbContextOptions<TestingGithubContext> options)
            : base(options)
        {
        }

        public DbSet<TestingGithub.Models.TestClass> TestClass { get; set; }
    }
}
