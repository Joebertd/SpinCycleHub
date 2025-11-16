using Microsoft.AspNetCore.Mvc;
using SpinCycleLaundryHub.Data;
using SpinCycleLaundryHub.Models;
using Microsoft.EntityFrameworkCore;

namespace SpinCycleLaundryHub.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.Include(o => o.Service).ToListAsync();
            return View(orders);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Services = await _context.Services.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order model)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Services = await _context.Services.ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Service)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();
            return View(order);
        }
    }
}
