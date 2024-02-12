using Microsoft.EntityFrameworkCore;
using Parcial1_AP1_AaronHernandez.Models;


namespace Parcial1_AP1_AaronHernandez.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Metas> Metas { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base (options) { }
    }
}
