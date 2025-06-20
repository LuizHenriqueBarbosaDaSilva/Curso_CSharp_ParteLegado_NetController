using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Curso2Legado___NetController.Models;

namespace Curso2Legado___NetController.Data
{
    public class CursoNetContext : DbContext
    {
        public CursoNetContext (DbContextOptions<CursoNetContext> options)
            : base(options)
        {
        }

        public DbSet<Curso2Legado___NetController.Models.Departament> Departament { get; set; } = default!;
    }
}
