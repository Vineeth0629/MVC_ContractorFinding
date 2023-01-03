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
    }
}
