using System.Collections.Generic;

namespace Diploma.Models
{
    class User
    {
        public int userId { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public virtual ICollection<UserData> UserDatas { get; set; }
    }
}
