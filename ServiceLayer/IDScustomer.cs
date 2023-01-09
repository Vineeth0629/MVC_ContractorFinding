using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IDScustomer
    {
        Task<IList<customer>> GetCustomer(string token);
        Task InsertCustomer(customer userMdl, string token);
        Task UpdateCustomer(customer userMdl, string token);
        Task deleteCustomer(customer userMdl, string token);
    }
}
