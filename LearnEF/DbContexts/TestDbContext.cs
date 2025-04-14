using LearnEF.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnEF.DbContexts;

public class TestDbContext : DbContext {
    
    public DbSet<Post> Posts { get; set; }

    public DbSet<Comment> Comments { get; set; }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

}