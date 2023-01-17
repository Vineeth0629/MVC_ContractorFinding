using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public partial class TbGender
    {
        public int GenderId { get; set; }

        public string? GenderType { get; set; }

        public virtual ICollection<ContractorDetail> ContractorDetails { get; } = new List<ContractorDetail>();
    }

}
