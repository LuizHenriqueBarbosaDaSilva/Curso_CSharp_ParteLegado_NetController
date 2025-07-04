using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Curso2Legado___NetController.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage ="{0} required")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage="Enter a valid email")]
        [Required(ErrorMessage = "{0} required")]
        public string Email { get; set; }
        [DisplayName("Dia de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "{0} required")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Salario base")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 50000.0, ErrorMessage="{0} must be from {1} to {2}")]
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
