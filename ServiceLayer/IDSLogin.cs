﻿using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IDSLogin
    {
        Task<IList<Login>> Logins();
        Task<string> ValidateUser(TbUser userMdl);

        Task<IEnumerable<Login>> postLogins(string emailId, string password);
    }
}
