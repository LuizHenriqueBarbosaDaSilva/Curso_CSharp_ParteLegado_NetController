namespace Curso2Legado___NetController.Models
{
    public class Departament
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Conexões
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        // Construtores
        public Departament() { }
        public Departament(int id, string name) 
        {
            Id = id;
            Name = name;  
        }

        // Metodos
        public void addSeller(Seller seller) { Sellers.Add(seller); }
        public double totalSales(DateTime initial, DateTime final) { return Sellers.Sum(seller => seller.totalSales(initial, final) ); }
    }
}
