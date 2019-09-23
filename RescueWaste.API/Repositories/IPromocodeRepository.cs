using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using RescueWaste.API.Models;

namespace RescueWaste.API.Repositories
{
    public interface IPromocodeRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<PromoCode>> GetPromocodes();
        Task<PromoCode> GetPromoCode(int promocodeId);
    }
}