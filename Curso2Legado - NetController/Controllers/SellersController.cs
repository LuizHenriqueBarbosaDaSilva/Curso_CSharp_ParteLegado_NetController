using Curso2Legado___NetController.Models;
using Curso2Legado___NetController.Models.ViewModels;
using Curso2Legado___NetController.Services;
using Curso2Legado___NetController.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Data;
using System.Diagnostics;

namespace Curso2Legado___NetController.Controllers
{
    public class SellersController : Controller
    {
        // Injeção de dependencia
        private readonly SellerService _sellerService;
        private readonly DepartamentService _departamentService;
        // Construtor
        public SellersController(SellerService sellerService, DepartamentService departamentService)
        {
            _sellerService = sellerService;
            _departamentService = departamentService;

        }

        // Corresponde ao metodo GET
        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.findAllAsync();
            return View(list);
        }

        // Corresponde ao metodo GET
        public async Task<IActionResult> Create()
        {
            var departaments = await _departamentService.findAllAsync();
            var viewModel = new SellerFormViewModel { Departaments = departaments };
            return View(viewModel);

        }

        // Corresponde ao metodo POST
        [HttpPost]
        [ValidateAntiForgeryToken] // Para proteger a sessão de ataques!
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departaments = await _departamentService.findAllAsync();
                var viewModel = new SellerFormViewModel {  Seller = seller, Departaments = departaments };
                return View(viewModel);
            }
            await _sellerService.InsertAsync(seller);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) { return RedirectToAction(nameof(Error), new { message ="Id não foi fornecido!" } );  }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null) { return RedirectToAction(nameof(Error), new { message ="Id não foi encontrado!" } ); }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _sellerService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) { return RedirectToAction(nameof(Error), new { message ="Id não foi fornecido!" } ); }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null) { return RedirectToAction(nameof(Error), new { message ="Id não foi encontrado!" } ); }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) { return RedirectToAction(nameof(Error), new { message ="Id não foi fornecido!" } ); }
            
            // Testa se esta no banco de dados!
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null) { return RedirectToAction(nameof(Error), new { message ="Id não foi encontrado!" } ); };

            List<Departament> departaments = await _departamentService.findAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departaments = departaments };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departaments = await _departamentService.findAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departaments = departaments };
                return View(viewModel);
            }
            if (id != seller.Id) { return RedirectToAction(nameof(Error), new { message = "Id diferente! Id mismatch!" }); }
            try
            {
                await _sellerService.UpdateAsync(seller);

                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e) 
            {
                return RedirectToAction(nameof(Error), new { message = e.Message } );
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel 
            { 
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
