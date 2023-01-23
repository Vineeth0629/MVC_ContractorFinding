using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IDsContract
    {
       
        Task<IList<ContractorDisplay>> GetContract(string token);
        Task CreateContractorDetail(ContractorDetail userMdl, string token);
        Task updatecontractor(ContractorDetail userMdl, string token);
        Task deletecontractor(string License, string token);
        Task<IList<ContractorDisplay>> SearchBypincode(string token, int pin);

    }
}
