using Agenda.API.Models;

namespace Agenda.API.Services.Interfaces
{
    public interface IAgendaService
    {
        Task<IEnumerable<Evento>> GetAgendaAsync();
        Task<Evento> GetEventoAsync(int id);
        Task AddEventoAsync(Evento evento);
        Task UpdateEventoAsync(Evento evento);
        Task DeleteEventoAsync(int id);
    }
}
