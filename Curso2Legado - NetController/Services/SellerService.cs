using Curso2Legado___NetController.Data;
using Curso2Legado___NetController.Models;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Curso2Legado___NetController.Services
{
    public class SellerService
    {
        private readonly  CursoNetContext _context;

        // Construtor 
        public SellerService(CursoNetContext context) {  _context = context; }

        // Operação Find All -> Retorna uma lista com todos vendedores! Nota: E uma operação sincrona
        public List<Seller> findAll() { return _context.Seller.ToList(); }
        // Insere no banco de dados os dados da pagina
        public void Insert(Seller obj) 
        {
            obj.Departament = _context.Departament.First();
           _context.Add(obj); 
           _context.SaveChanges();
        }
    }
}
