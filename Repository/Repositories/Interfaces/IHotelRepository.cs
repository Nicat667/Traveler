using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IHotelRepository : IBaseRepository<Hotel>
    {
        Task<IEnumerable<Hotel>> GetAllHotel();
        Task<Hotel> GetHotelById(int id);
        Task<IEnumerable<Hotel>> GetAllPaginated(int page, int take);
    }
}
