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
    public class CinemaController : Controller
    {
        private readonly ICinemaService _service;

        public CinemaController(ICinemaService service)
        {
            _service = service;
        }

        // GET: Cinemas
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: Cinemas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var Cinema = await _service.GetByIdAsync(id);
            if (Cinema == null) return View("Not Found");
            return View(Cinema);
        }

        // GET: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cinemas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Bio,ImageUrl")] Cinema Cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(Cinema);
            }

            await _service.AddAsync(Cinema);

            return RedirectToAction(nameof(Index));
        }

        // GET: Cinemas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return View(data);
        }

        // POST: Cinemas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Bio,ImageUrl")] Cinema Cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(id);
            }
            await _service.UpdateAsync(Cinema);
            return RedirectToAction(nameof(Index));
        }

        // GET: Cinemas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var CinemaDetails = await _service.GetByIdAsync(id);
            if (CinemaDetails == null) return View("Not Found");
            return View(CinemaDetails);
        }

        // POST: Cinemas/Delete/5
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
