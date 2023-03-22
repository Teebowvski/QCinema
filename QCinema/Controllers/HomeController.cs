using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QCinema.Data.Services;

using QCinema.Models;
using QCinema.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QCinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _service;
        private readonly IGenreService _genreservice;

        public HomeController(IMovieService service, IGenreService genreservice)
        {
            _service = service;
            _genreservice = genreservice;
          
            
        }

        
        

        public IActionResult Index()
        {
         

            var homeViewModel = new MoviesListviewModel
            {
                Movies = _service.Movies(),
                Genres = _genreservice.Genres()
                


            };
            return View(homeViewModel);
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
