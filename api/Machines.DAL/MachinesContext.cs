using Microsoft.EntityFrameworkCore;
using Machines.Models.Db;
namespace Machines.DAL
{
    public class MachinesContext: DbContext
    {
        public MachinesContext(DbContextOptions<MachinesContext> options) : base(options)
        {
        }

        public DbSet<Machine> Machine { get; set; }      
    }
}
