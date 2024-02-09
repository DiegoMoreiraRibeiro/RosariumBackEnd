using Microsoft.EntityFrameworkCore;

public class MyApplicationDbContext : DbContext
{
    public MyApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

  
}