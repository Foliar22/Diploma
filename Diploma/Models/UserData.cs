using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Models
{
    class UserData
    {
        public long recordId { get; set; }
        public long userId { get; set; }
        public virtual User user { get; set; }
        public string path { get; set; }
        public string name { get; set; }
    }
}
