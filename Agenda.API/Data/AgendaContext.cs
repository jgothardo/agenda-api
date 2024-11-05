using Agenda.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.API.Data
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }
    }
}
