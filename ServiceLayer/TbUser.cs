using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{

    public class TbUser
    {
        public int userId { get; set; }
        public int typeUser { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailId { get; set; }
        public string password { get; set; }
        public int phoneNumber { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        public bool active { get; set; }
        public int roleId { get; set; }
        public TypeUserNavigation typeUserNavigation { get; set; }
    }

    public class TypeUserNavigation
    {
        public int typeId { get; set; }
        public string usertype1 { get; set; }
    }



}
