using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels.FAQ;
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

        public async Task<IEnumerable<FAQVM>> GetAll()
        {
            var datas = await _fAQRepository.GetAllAsync();
            return datas.Select(x => new FAQVM
            {
                Answer = x.Answer,
                Question = x.Question,
            });
        }
    }
}
