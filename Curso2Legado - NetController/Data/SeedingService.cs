using Curso2Legado___NetController.Models;
using Curso2Legado___NetController.Models.Enums;

namespace Curso2Legado___NetController.Data
{
    public class SeedingService
    {
        // Ganha o contexto do banco de dados
        private CursoNetContext _context;

        // Construtor
        public SeedingService(CursoNetContext context) { _context = context; }

        // Metodo ou operação
        public void Seed()
        {
            if (_context.Departament.Any() || _context.Seller.Any() || _context.SalesRecord.Any()) { return; /* O banco de dados ja foi populado! */ }


            // Instanciação de Departament
            Departament d1 = new Departament(1, "Computers");
            Departament d2 = new Departament(2, "Electronics");
            Departament d3 = new Departament(3, "Fashion");
            Departament d4 = new Departament(4, "Books");

            // Instanciação de Sellers
            Seller s1 = new Seller(1, "Bob brown","bob@gmail.com", new DateTime(1998,4,21), 1000.00, d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.00, d2);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.00, d1);
            Seller s4 = new Seller(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.00, d4);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.00, d3);
            Seller s6 = new Seller(6, "Alex Pink", "alexp@gmail.com", new DateTime(1997, 3, 4), 3000.00, d2);

            // Instanciação de SalesRecord
            SalesRecord r1 = new(1, new DateTime(2018, 09, 25, 0, 0, 0, 0, DateTimeKind.Local), 11000.0, SaleStatus.BILLED, s1);
            SalesRecord r2 = new(2, new DateTime(2018, 09, 4, 0, 0, 0, 0, DateTimeKind.Local), 7000.0, SaleStatus.BILLED, s5);
            SalesRecord r3 = new(3, new DateTime(2018, 09, 13, 0, 0, 0, 0, DateTimeKind.Local), 4000.0, SaleStatus.CANCELED, s4);
            SalesRecord r4 = new(4, new DateTime(2018, 09, 1, 0, 0, 0, 0, DateTimeKind.Local), 8000.0, SaleStatus.BILLED, s1);
            SalesRecord r5 = new(5, new DateTime(2018, 09, 21, 0, 0, 0, 0, DateTimeKind.Local), 3000.0, SaleStatus.BILLED, s3);
            SalesRecord r6 = new(6, new DateTime(2018, 09, 15, 0, 0, 0, 0, DateTimeKind.Local), 2000.0, SaleStatus.BILLED, s1);
            SalesRecord r7 = new(7, new DateTime(2018, 09, 28, 0, 0, 0, 0, DateTimeKind.Local), 13000.0, SaleStatus.BILLED, s2);
            SalesRecord r8 = new(8, new DateTime(2018, 09, 11, 0, 0, 0, 0, DateTimeKind.Local), 4000.0, SaleStatus.BILLED, s4);
            SalesRecord r9 = new(9, new DateTime(2018, 09, 14, 0, 0, 0, 0, DateTimeKind.Local), 11000.0, SaleStatus.PENDING, s6);
            SalesRecord r10 = new(10, new DateTime(2018, 09, 7, 0, 0, 0, 0, DateTimeKind.Local), 9000.0, SaleStatus.BILLED, s6);
            SalesRecord r11 = new(11, new DateTime(2018, 09, 13, 0, 0, 0, 0, DateTimeKind.Local), 6000.0, SaleStatus.BILLED, s2);
            SalesRecord r12 = new(12, new DateTime(2018, 09, 25, 0, 0, 0, 0, DateTimeKind.Local), 7000.0, SaleStatus.PENDING, s3);
            SalesRecord r13 = new(13, new DateTime(2018, 09, 29, 0, 0, 0, 0, DateTimeKind.Local), 10000.0, SaleStatus.BILLED, s4);
            SalesRecord r14 = new(14, new DateTime(2018, 09, 4, 0, 0, 0, 0, DateTimeKind.Local), 3000.0, SaleStatus.BILLED, s5);
            SalesRecord r15 = new(15, new DateTime(2018, 09, 12, 0, 0, 0, 0, DateTimeKind.Local), 4000.0, SaleStatus.BILLED, s1);
            SalesRecord r16 = new(16, new DateTime(2018, 10, 5, 0, 0, 0, 0, DateTimeKind.Local), 2000.0, SaleStatus.BILLED, s4);
            SalesRecord r17 = new(17, new DateTime(2018, 10, 1, 0, 0, 0, 0, DateTimeKind.Local), 12000.0, SaleStatus.BILLED, s1);
            SalesRecord r18 = new(18, new DateTime(2018, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 6000.0, SaleStatus.BILLED, s3);
            SalesRecord r19 = new(19, new DateTime(2018, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 8000.0, SaleStatus.BILLED, s5);
            SalesRecord r20 = new(20, new DateTime(2018, 10, 15, 0, 0, 0, 0, DateTimeKind.Local), 8000.0, SaleStatus.BILLED, s6);
            SalesRecord r21 = new(21, new DateTime(2018, 10, 17, 0, 0, 0, 0, DateTimeKind.Local), 9000.0, SaleStatus.BILLED, s2);
            SalesRecord r22 = new(22, new DateTime(2018, 10, 24, 0, 0, 0, 0, DateTimeKind.Local), 4000.0, SaleStatus.BILLED, s4);
            SalesRecord r23 = new(23, new DateTime(2018, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), 11000.0, SaleStatus.CANCELED, s2);
            SalesRecord r24 = new(24, new DateTime(2018, 10, 12, 0, 0, 0, 0, DateTimeKind.Local), 8000.0, SaleStatus.BILLED, s5);
            SalesRecord r25 = new(25, new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Local), 7000.0, SaleStatus.BILLED, s3);
            SalesRecord r26 = new(26, new DateTime(2018, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), 5000.0, SaleStatus.BILLED, s4);
            SalesRecord r27 = new(27, new DateTime(2018, 10, 13, 0, 0, 0, 0, DateTimeKind.Local), 9000.0, SaleStatus.PENDING, s1);
            SalesRecord r28 = new(28, new DateTime(2018, 10, 7, 0, 0, 0, 0, DateTimeKind.Local), 4000.0, SaleStatus.BILLED, s3);
            SalesRecord r29 = new(29, new DateTime(2018, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), 12000.0, SaleStatus.BILLED, s5);
            SalesRecord r30 = new(30, new DateTime(2018, 10, 12, 0, 0, 0, 0, DateTimeKind.Local), 5000.0, SaleStatus.BILLED, s2);


            _context.Departament.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4,s5,s6);
            _context.SalesRecord.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11,
                r12, r13, r14, r15, r16, r17, r18, r19, r20, r21,
                r22, r23, r24, r25, r26, r27, r28, r29, r30
                );

            _context.SaveChanges();
        }
    }
}
