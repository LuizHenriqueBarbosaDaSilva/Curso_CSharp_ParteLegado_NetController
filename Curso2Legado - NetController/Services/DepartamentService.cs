using Curso2Legado___NetController.Data;
using Curso2Legado___NetController.Models;

namespace Curso2Legado___NetController.Services
{
    public class DepartamentService
    {
        private readonly CursoNetContext _context;

        // Construtor 
        public DepartamentService(CursoNetContext context) { _context = context; }

        // Operação Find All -> Retorna uma lista com todos vendedores! Nota: E uma operação sincrona
        public List<Departament> findAll() { return _context.Departament.OrderBy(x => x.Name).ToList(); }


    }
}
