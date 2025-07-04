using Curso2Legado___NetController.Data;
using Curso2Legado___NetController.Models;
using Microsoft.EntityFrameworkCore;

namespace Curso2Legado___NetController.Services
{
    public class DepartamentService
    {
        private readonly CursoNetContext _context;

        // Construtor 
        public DepartamentService(CursoNetContext context) { _context = context; }

        // Operação Find All -> Retorna uma lista com todos vendedores! Nota: E uma operação sincrona
        public async Task<List<Departament>> findAllAsync() 
        { 
            return await _context.Departament.OrderBy(x => x.Name).ToListAsync();
        }


    }
}
