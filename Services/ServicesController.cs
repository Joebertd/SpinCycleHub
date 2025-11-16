using Microsoft.AspNetCore.Mvc;
using SpinCycleLaundryHub.Data;
using SpinCycleLaundryHub.Models;
using Microsoft.EntityFrameworkCore;

namespace SpinCycleLaundryHub.Controllers
{
    public class ServicesController : Controller
    {
        private readonly AppDbContext _context;

        public ServicesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _context.Services.ToListAsync();
            return View(services);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Service model)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return NotFound();
            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Service model)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return NotFound();

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
