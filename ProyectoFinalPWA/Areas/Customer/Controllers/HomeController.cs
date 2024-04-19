using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.DataAccess.Repository.IRepository;
using ProyectoFinal.Models;
using ProyectoFinal.Utility;
using System.Diagnostics;
using System.Net;
using System.Security.Claims;

namespace ProyectoFinalPWA.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string? category = null, string? priceRange = null, string? author = null)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                HttpContext.Session.SetInt32(SD.SessionCart,
                _unitOfWork.ShoppingCart.GetAll(sC => sC.ApplicationUserId == claim.Value).Count());
            }

            var query = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages");

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category.Name.Equals(category));
            }

            if (!string.IsNullOrEmpty(author))
            {
                var decodedAuthor = WebUtility.UrlDecode(author);
                query = query.Where(p => p.Author.Equals(decodedAuthor));
            }

            if (!string.IsNullOrEmpty(priceRange))
            {
                var prices = priceRange.Split('-');
                double priceLow = double.Parse(prices[0]);
                double priceHigh = double.Parse(prices[1]);
                query = query.Where(p => p.Price >= priceLow && p.Price <= priceHigh);
            }

            var productList = query.ToList();
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            ShoppingCart cart = new()
            {
                Product = _unitOfWork.Product.GetFirstOrDefault(pro => pro.Id == productId, includeProperties: "Category,ProductImages"),
                Count = 1,
                ProductId = productId
            };
            return View(cart);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;

            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(sC => sC.ApplicationUserId == userId && sC.ProductId == shoppingCart.ProductId);

            if (cartFromDb != null)
            {
                cartFromDb.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
                _unitOfWork.Save();
            } else
            {
                _unitOfWork.ShoppingCart.Add(shoppingCart);
                _unitOfWork.Save();
                HttpContext.Session.SetInt32(SD.SessionCart,
                 _unitOfWork.ShoppingCart.GetAll(sC => sC.ApplicationUserId == userId).Count());
            }       


            TempData["success"] = "Carrito actualizado correctamente";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
