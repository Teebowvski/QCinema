using Microsoft.AspNetCore.Mvc;
using QCinema.Data.Services;
using QCinema.Models;
using QCinema.ViewModels;
using System.Linq;

namespace QCinema.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IMovieService _service;
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartController(IMovieService service, ShoppingCart shoppingCart)
        {
            _service= service;
            _shoppingCart=shoppingCart;
        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(sCVM);
        }

        public RedirectToActionResult AddToShoppingCart(int movieId)
        {
            var selectedMovie = _service.Movies().FirstOrDefault(x => x.Id == movieId);
            if(selectedMovie != null)
            {
                _shoppingCart.AddToCart(selectedMovie, 1);
            }
            return RedirectToAction("Index");
        }

        public  RedirectToActionResult RemoveFromShoppingCart(int movieId)
        {
            var selectedMovie =  _service.Movies().FirstOrDefault(p=>p.Id == movieId);
            if (selectedMovie != null)
            {
                _shoppingCart.RemoveFromCart(selectedMovie);
            }
            return RedirectToAction("Index");
        }
    }
}
