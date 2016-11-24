using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Mapper.Test
{
    public class VipUser : User
    {
        public Int32 Grade { get; set; }

        public VipUser()
        {
        }
        public VipUser(String name)
            : base(name)
        {

        }
    }
    public class UserListInfo
    {
        public String GroupName { get; set; }
        public List<User> Users { get; set; }

        public UserListInfo()
        {
            this.Users = new List<User>();
        }
    }
    public class VipUserListInfo
    {
        public String GroupName { get; set; }
        public List<VipUser> Users { get; set; }

        public VipUserListInfo()
        {
            this.Users = new List<VipUser>();
        }
    }
}
