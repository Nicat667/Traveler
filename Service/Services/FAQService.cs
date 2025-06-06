using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class FAQService : IFAQService
    {
        private readonly IFAQRepository _fAQRepository;
        public FAQService(IFAQRepository fAQRepository)
        {
            _fAQRepository = fAQRepository;
        }
    }
}
