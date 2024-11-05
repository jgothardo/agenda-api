namespace Agenda.API.Models
{
    public class Evento
    {
        public int Id { get; set; } // Identificador único do evento
        public string Nome { get; set; } // Nome do evento
        public string Descricao { get; set; } // Descrição do evento
        public DateTime DataInicio { get; set; } // Data de início do evento
        public DateTime DataFinal { get; set; } // Data de término do evento
        public string Local { get; set; } // Local do evento
    }
}
