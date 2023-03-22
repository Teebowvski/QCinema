using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QCinema.Data;
using QCinema.Data.Services;
using QCinema.Models;
using QCinema.ViewModels;

namespace QCinema.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _service;
        private readonly IGenreService _genreService;
        private readonly IActorService _actorService;
        private readonly ICategoryService _categoryService;
        private readonly ICinemaService _cinemaService;
        private readonly IProducerService _producerService;


        public MovieController(IMovieService service, IGenreService genreService, IActorService actorService,ICategoryService categoryService,ICinemaService cinemaService, IProducerService producerService)
        {
            _service = service;
            _genreService = genreService;
            _actorService = actorService;
            _categoryService = categoryService;
            _cinemaService = cinemaService;
            _producerService = producerService;


        }
        // GET: MovieController
        public async Task<ActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public async Task<ViewResult> List(string genre)
        {
            IEnumerable<Movie> movies;
            string _genre = genre;

            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(genre))
            {
                movies = _service.Movies().OrderBy(x => x.Id);
                genre = "All Movies";
            }
            else
            {
                if (string.Equals("Action", _genre, StringComparison.OrdinalIgnoreCase))
                {
                    movies = _service.Movies().Where(x => x.Genre.Name.Equals("Action")).OrderBy(x => x.Name);
                }
                else
                {
                    movies = _service.Movies().Where(x => x.Genre.Name.Equals("Sci-Fi")).OrderBy(x => x.Name);
                }

                genre = _genre;

            }






            var moviesListViewModel = new MoviesListviewModel
            {
                Movies = _service.Movies(),
                Genres = _genreService.Genres(),
                
            };
            return View(moviesListViewModel);

        }
        public async Task<ActionResult> MovieDetails(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return View(data);
        }
        // GET: MovieController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return View(data);
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {



            ViewBag.Genres = new SelectList(_genreService.Genres(), "Id", "Name");
            ViewBag.Actors = new SelectList(_actorService.Actors(), "Id", "Name");
            ViewBag.Producers = new SelectList(_producerService.Producers(), "Id", "Name");
            ViewBag.Categories = new SelectList(_categoryService.CurrentCategory(), "Id", "Name");
            ViewBag.Cinemas = new SelectList(_cinemaService.Cinemas(), "Id", "Name");
            return View();


        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Name,Price,StartDate,EndDate,Description,LongDescription,ImageUrl,GenreId,ProducerId,CinemaId,ActorId")] Movie movie)
        {
            if (!ModelState.IsValid)
            {
               
                return View(movie);
            }
           
            await _service.AddAsync(movie);
            ViewBag.Genres = new SelectList(_genreService.Genres(), "Id", "Name");
            ViewBag.Actors = new SelectList(_actorService.Actors(), "Id", "Name");
            ViewBag.Producers = new SelectList(_producerService.Producers(), "Id", "Name");
            ViewBag.Categories = new SelectList(_categoryService.CurrentCategory(), "Id", "Name");
            ViewBag.Cinemas = new SelectList(_cinemaService.Cinemas(), "Id", "Name");
            return RedirectToAction(nameof(Index));

           
        }

        // GET: MovieController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetByIdAsync(id);
            if (movieDetails == null) return View("Not Found");
            ViewBag.Genres = new SelectList(_genreService.Genres(), "Id", "Name");
            ViewBag.Actors = new SelectList(_actorService.Actors(), "Id", "Name");
            ViewBag.Producers = new SelectList(_producerService.Producers(), "Id", "Name");
            ViewBag.Categories = new SelectList(_categoryService.CurrentCategory(), "Id", "Name");
            ViewBag.Cinemas = new SelectList(_cinemaService.Cinemas(), "Id", "Name");
            return View(movieDetails);
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("Id,Name,Price,StartDate,EndDate,Description,LongDescription,ImageUrl,Genre,Producer,Cinema,Actor")] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(id);
            }
          
            await _service.UpdateAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        // GET: MovieController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var movieDetails = await _service.GetByIdAsync(id);
            if (movieDetails == null) return View("Not Found");
            return View(movieDetails);
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var data = _service.GetByIdAsync(id);
            if (data == null) return View("Not Found");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

       
    }

    
}
