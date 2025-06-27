namespace Curso2Legado___NetController.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }

        // Conexões 
        public Departament Departament { get; set; }
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
