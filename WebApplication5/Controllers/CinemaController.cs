﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Data.Repository;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class CinemaController : Controller
    {
        private readonly IActorRepository _repository;
        public CinemaController(IActorRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            await _repository.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _repository.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _repository.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            await _repository.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _repository.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinemaDetails = await _repository.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");

            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
