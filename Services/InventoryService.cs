using SpinCycleHub.Models;

namespace SpinCycleHub.Services
{
    public class InventoryService
    {
        private readonly ApplicationDbContext _db;

        public InventoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> GetSoapStockAsync() =>
            await Task.FromResult(20); // placeholder

        public async Task<int> GetFabricSoftenerStockAsync() =>
            await Task.FromResult(15);

        public async Task<int> GetBleachStockAsync() =>
            await Task.FromResult(10);
    }
}
