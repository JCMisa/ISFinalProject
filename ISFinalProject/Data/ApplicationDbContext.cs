using ISFinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ISFinalProject.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Barangay?> Barangays { get; set; }
	}
}
