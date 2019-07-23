using Microsoft.EntityFrameworkCore;
using RescueWaste.API.Models;

namespace RescueWaste.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){ }
        public DbSet<Test> Tests {get; set;}
    }
}