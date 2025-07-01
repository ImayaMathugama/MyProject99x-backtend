using Microsoft.EntityFrameworkCore;
using MyBackendApi.Models;
using System.Collections.Generic;

namespace MyBackendApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}


