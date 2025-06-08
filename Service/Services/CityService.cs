using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<CityVM>> GetAllWihHotelsAsync()
        {
            var datas = await _cityRepository.GetAllWithHotels();
            return datas.Select(x => new CityVM
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                HotelCount = x.Hotels.Count,
            });
        }

        
        
    }
}
