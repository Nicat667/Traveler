using Service.ViewModels.FAQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IFAQService
    {
        Task<IEnumerable<FAQVM>> GetAll();
    }
}
