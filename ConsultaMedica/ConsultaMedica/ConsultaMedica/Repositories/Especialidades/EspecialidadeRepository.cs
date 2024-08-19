using Microsoft.EntityFrameworkCore;
using ConsultaMedica.Data;
using ConsultaMedica.Models;

namespace ConsultaMedica.Repositories.Especialidades
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Especialidade>> GetAllAsync()
        {
            return await _context
                .Especialidades
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
