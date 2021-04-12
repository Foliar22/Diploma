using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Models
{
    class User
    {
        public long userId { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public virtual ICollection<UserData> UserDatas { get; set; }
    }
}
