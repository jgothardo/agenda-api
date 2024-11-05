using Agenda.API.Models;
using Agenda.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Agenda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaService _agendaService;

        public AgendaController(IAgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        // GET: api/Events
        [HttpGet]
        [SwaggerOperation(Summary = "Recupera todos os eventos da agenda", Description = "Obtém uma lista de todos os eventos na agenda.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna a lista de eventos", typeof(IEnumerable<Evento>))]
        public async Task<ActionResult<IEnumerable<Evento>>> GetAgenda()
        {
            var eventos = await _agendaService.GetAgendaAsync();
            return Ok(eventos);
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Recupera um evento específico", Description = "Obtém um evento específico pelo seu ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna o evento", typeof(Evento))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Evento não encontrado")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var evento = await _agendaService.GetEventoAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            return Ok(evento);
        }

        // POST: api/Events
        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo evento", Description = "Cria um novo evento na agenda.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Evento criado com sucesso", typeof(Evento))]
        public async Task<ActionResult<Evento>> PostEvento(Evento evento)
        {
            await _agendaService.AddEventoAsync(evento);
            return CreatedAtAction(nameof(GetEvento), new { id = evento.Id }, evento);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um evento existente", Description = "Atualiza um evento existente pelo seu ID.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Evento atualizado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "ID do evento inválido")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Evento não encontrado")]
        public async Task<IActionResult> PutEvento(int id, Evento evento)
        {
            if (id != evento.Id)
            {
                return BadRequest();
            }

            try
            {
                await _agendaService.UpdateEventoAsync(evento);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui um evento", Description = "Exclui um evento pelo seu ID.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Evento excluído com sucesso")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Evento não encontrado")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            try
            {
                await _agendaService.DeleteEventoAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}