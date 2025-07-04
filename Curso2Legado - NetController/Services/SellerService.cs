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
        public async Task<List<Seller>> findAllAsync() { return await _context.Seller.ToListAsync(); }
        // Insere no banco de dados os dados da pagina
        public async Task InsertAsync(Seller obj) 
        {
           _context.Add(obj); 
           await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Departament).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny) { throw new NotFoundException("Id não foi encontrado!");  }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            } 
            catch (DbUpdateConcurrencyException e) 
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }
  
    }
}
