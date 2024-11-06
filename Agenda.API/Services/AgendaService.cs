using Agenda.API.Data;
using Agenda.API.Models;
using Agenda.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Globalization;

namespace Agenda.API.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly AgendaContext _context;
        private readonly string _excelFilePath = "Agenda.xlsx";

        public AgendaService(AgendaContext context)
        {
            _context = context;

            // Initialize the Excel package
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        public void Initialize()
        {
            if (File.Exists(_excelFilePath))
            {
                LoadEventosFromExcel();
            }
            else
            {
                using (var package = new ExcelPackage(new FileInfo(_excelFilePath)))
                {
                    var worksheet = package.Workbook.Worksheets.Add("Eventos");
                    worksheet.Cells["A1"].Value = "ID";
                    worksheet.Cells["B1"].Value = "Nome";
                    worksheet.Cells["C1"].Value = "Descricao";
                    worksheet.Cells["D1"].Value = "DataInicio";
                    worksheet.Cells["E1"].Value = "DataFinal";
                    worksheet.Cells["F1"].Value = "Local";
                    package.Save();
                }
            }
        }

        public async Task<IEnumerable<Evento>> GetAgendaAsync()
        {
            return await _context.Eventos.AsNoTracking().ToListAsync();
        }

        public async Task<Evento?> GetEventoAsync(int id)
        {
            return await _context.Eventos.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddEventoAsync(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
            await UpdateExcelAsync();
        }

        public async Task UpdateEventoAsync(Evento evento)
        {
            var existingEvento = await _context.Eventos.FindAsync(evento.Id);
            if (existingEvento != null)
            {
                existingEvento.Nome = evento.Nome;
                existingEvento.Descricao = evento.Descricao;
                existingEvento.DataInicio = evento.DataInicio;
                existingEvento.DataFinal = evento.DataFinal;
                existingEvento.Local = evento.Local;

                _context.Entry(existingEvento).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await UpdateExcelAsync();
            }
        }

        public async Task DeleteEventoAsync(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento != null)
            {
                _context.Eventos.Remove(evento);
                await _context.SaveChangesAsync();
                await UpdateExcelAsync();
            }
        }

        private async Task UpdateExcelAsync()
        {
            var eventos = await _context.Eventos.AsNoTracking().ToListAsync();

            using (var package = new ExcelPackage(new FileInfo(_excelFilePath)))
            {
                var worksheet = package.Workbook.Worksheets["Eventos"];
                worksheet.Cells.Clear();
                worksheet.Cells["A1"].Value = "ID";
                worksheet.Cells["B1"].Value = "Nome";
                worksheet.Cells["C1"].Value = "Descricao";
                worksheet.Cells["D1"].Value = "DataInicio";
                worksheet.Cells["E1"].Value = "DataFinal";
                worksheet.Cells["F1"].Value = "Local";

                var row = 2;
                foreach (var evento in eventos)
                {
                    worksheet.Cells[row, 1].Value = evento.Id;
                    worksheet.Cells[row, 2].Value = evento.Nome;
                    worksheet.Cells[row, 3].Value = evento.Descricao;
                    worksheet.Cells[row, 4].Value = evento.DataInicio;
                    worksheet.Cells[row, 4].Value = evento.DataInicio.ToString("dd/MM/yyyy", new CultureInfo("pt-BR"));
                    worksheet.Cells[row, 5].Value = evento.DataFinal;
                    worksheet.Cells[row, 5].Value = evento.DataFinal.ToString("dd/MM/yyyy", new CultureInfo("pt-BR"));
                    worksheet.Cells[row, 6].Value = evento.Local;
                    row++;
                }

                await package.SaveAsync();
            }
        }

        private void LoadEventosFromExcel()
        {
            using (var package = new ExcelPackage(new FileInfo(_excelFilePath)))
            {
                var worksheet = package.Workbook.Worksheets["Eventos"];
                if (worksheet == null) return;

                var rowCount = worksheet.Dimension.Rows;
                for (int row = 2; row <= rowCount; row++)
                {
                    var evento = new Evento
                    {
                        Id = int.Parse(worksheet.Cells[row, 1].Text),
                        Nome = worksheet.Cells[row, 2].Text,
                        Descricao = worksheet.Cells[row, 3].Text,
                        DataInicio = DateTime.ParseExact(worksheet.Cells[row, 4].Text, "dd/MM/yyyy", new CultureInfo("pt-BR")),
                        DataFinal = DateTime.ParseExact(worksheet.Cells[row, 5].Text, "dd/MM/yyyy", new CultureInfo("pt-BR")),
                        Local = worksheet.Cells[row, 6].Text
                    };

                    // Verifica se o evento já existe no banco de dados
                    if (!_context.Eventos.AsNoTracking().Any(e => e.Id == evento.Id))
                    {
                        _context.Eventos.Add(evento);
                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}