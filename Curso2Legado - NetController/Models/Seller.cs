using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Curso2Legado___NetController.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Dia de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Salario base")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }

        // Conexões 
        public Departament Departament { get; set; }
        [DisplayName("Departamento atribuido")]
        public int DepartamentId { get; set; }
        public ICollection<SalesRecord> SalesList { get; set; } = new List<SalesRecord>();

        // Construtores
        public Seller() { }
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        // Metodos
        public void addSales(SalesRecord sr) { SalesList.Add(sr); }
        public void removeSales(SalesRecord sr) { SalesList.Remove(sr); }
        public double totalSales(DateTime initial, DateTime Final) { return SalesList.Where(sr => sr.Date >= initial && sr.Date <= Final).Sum(sr => sr.Amount); }

    }
}
