using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RescueWaste.API.Data;
using RescueWaste.API.Models;

namespace RescueWaste.API.Repositories
{
    public class PromocodeRepository : IPromocodeRepository
    {
        private readonly DataContext _context;

        public PromocodeRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<PromoCode> GetPromoCode(int promocodeId)
        {
            var promoCode = await _context.PromoCodes
                .Include(p =>p.PromocodePhoto)
                .Include(m =>m.Merchant)
                .FirstOrDefaultAsync(p => p.Id == promocodeId);
            return promoCode;
        }

        public async Task<IEnumerable<PromoCode>> GetPromocodes()
        {
            var promoCodes = await _context.PromoCodes
                        .Include(p =>p.PromocodePhoto)
                        .Include(p =>p.Merchant)
                        .ToListAsync();
            return promoCodes;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}