using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public partial class Contract
    {
        public int? ContractorId { get; set; }

        public string CompanyName { get; set; } = null!;

        public int? Gender { get; set; }

        public string License { get; set; } = null!;

        public int? Services { get; set; }

        public double? Lattitude { get; set; }

        public double? Longitude { get; set; }

        public int Pincode { get; set; }

        public long? PhoneNumber { get; set; }

        public virtual TbUser? Contractor { get; set; }

        public virtual TbGender? GenderNavigation { get; set; }

        public virtual ServiceProviding? ServicesNavigation { get; set; }
    }


    public class ContractorDisplay : Contract
    {
        public string? Services { get; set; }
        public string? Gender { get; set; }
        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public string EmailId { get; set; } = null!;
    }
}
