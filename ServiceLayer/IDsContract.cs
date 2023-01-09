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
        Task<IList<Contract>> GetContract(string token);
        Task InsertContractor(Contract userMdl, string token);
        //Task UpdateContractor(Contract userMdl, string token);
        //Task deleteContractor(Contract userMdl, string token);
    }
}
