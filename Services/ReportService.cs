using Microsoft.EntityFrameworkCore;
using SpinCycleHub.Data;

namespace SpinCycleHub.Services
{
    public class ReportService
    {
        private readonly ApplicationDbContext _db;

        public ReportService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<decimal> GetTodayIncomeAsync()
        {
            var today = DateTime.Today;
            return await _db.Transactions
                .Where(t => t.CreatedAt.Date == today)
                .SumAsync(t => (decimal?)t.Total ?? 0);
        }

        public async Task<int> GetTodayOrdersAsync()
        {
            var today = DateTime.Today;
            return await _db.Transactions
                .CountAsync(t => t.CreatedAt.Date == today);
        }

        public async Task<List<(string Label, decimal Value)>> GetWeeklyIncomeAsync()
        {
            DateTime start = DateTime.Today.AddDays(-6);

            var data = await _db.Transactions
                .Where(t => t.CreatedAt.Date >= start)
                .GroupBy(t => t.CreatedAt.Date)
                .Select(g => new { Date = g.Key, Total = g.Sum(x => x.Total) })
                .ToListAsync();

            return data
                .OrderBy(e => e.Date)
                .Select(e => (e.Date.ToString("MMM dd"), e.Total))
                .ToList();
        }
    }
}
