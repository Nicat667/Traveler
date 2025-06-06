using Domain.Models;
using Service.ViewModels.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityVM>> GetAllWihHotelsAsync();

    }
}
