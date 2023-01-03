using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels
{
    public class Contract
    {
        public string Services { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public int ContractorId { get; set; }
        public string CompanyName { get; set; }
        public string License { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }
        public int Pincode { get; set; }
        public long PhoneNumber { get; set; }
        public object Contractor { get; set; }
        public object GenderNavigation { get; set; }
        public object ServicesNavigation { get; set; }
    }
}
