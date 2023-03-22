using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QCinema.Data.Services;
using QCinema.Data;
using QCinema.Models;

namespace QCinema.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _service;

        public GenreController(IGenreService service)
        {
            _service = service;
        }

        // GET: Genres
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: Genres/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var Genre = await _service.GetByIdAsync(id);
            if (Genre == null) return View("Not Found");
            return View(Genre);
        }

        // GET: Genres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Genre Genre)
        {
            if (!ModelState.IsValid)
            {
                return View(Genre);
            }

            await _service.AddAsync(Genre);

            return RedirectToAction(nameof(Index));
        }

        // GET: Genres/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return View(data);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Genre Genre)
        {
            if (!ModelState.IsValid)
            {
                return View(id);
            }
            await _service.UpdateAsync(Genre);
            return RedirectToAction(nameof(Index));
        }

        // GET: Genres/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var GenreDetails = await _service.GetByIdAsync(id);
            if (GenreDetails == null) return View("Not Found");
            return View(GenreDetails);
        }

        // POST: Genres/Delete/5
        [HttpPost]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!ModelState.IsValid)
            {
                return View(id);
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }


    }
}
