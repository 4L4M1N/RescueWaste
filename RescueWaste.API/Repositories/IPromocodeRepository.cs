using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using RescueWaste.API.Helpers;
using RescueWaste.API.Models;

namespace RescueWaste.API.Repositories
{
    public interface IPromocodeRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<PagingList<PromoCode>> GetPromocodes(PromocodeParams promocodeParams);
        Task<PromoCode> GetPromoCode(int promocodeId);
    }
}