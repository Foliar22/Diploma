using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Models
{
    class UserData
    {
        public int recordId { get; set; }
        public int userId { get; set; }
        public virtual User user { get; set; }
        public string path { get; set; }
        public string name { get; set; }
    }
}
