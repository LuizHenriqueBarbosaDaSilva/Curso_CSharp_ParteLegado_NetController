using Curso2Legado___NetController.Models;
using Curso2Legado___NetController.Services;
using Microsoft.AspNetCore.Mvc;

namespace Curso2Legado___NetController.Controllers
{
    public class SellersController : Controller
    {
        // Injeção de dependencia
        private readonly SellerService _sellerService;
        // Construtor
        public SellersController(SellerService sellerService) { _sellerService = sellerService; }

        // Corresponde ao metodo GET
        public IActionResult Index()
        {
            var list = _sellerService.findAll();
            return View(list);
        }

        // Corresponde ao metodo GET
        public IActionResult Create()
        {
            return View();
        }

        // Corresponde ao metodo POST
        [HttpPost]
        [ValidateAntiForgeryToken] // Para proteger a sessão de ataques!
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
            
        }
    }
}
