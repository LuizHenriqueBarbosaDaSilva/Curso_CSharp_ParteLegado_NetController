using Curso2Legado___NetController.Data;
using Curso2Legado___NetController.Models;
using Curso2Legado___NetController.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
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
           _context.Add(obj); 
           _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Departament).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id)) { throw new NotFoundException("Id não foi encontrado!");  }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            } 
            catch (DbUpdateConcurrencyException e) 
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }
  
    }
}
