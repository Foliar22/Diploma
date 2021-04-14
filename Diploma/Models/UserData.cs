using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diploma.Models
{
    class UserData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid recordId { get; set; }
        public int userId { get; set; }
        public virtual User user { get; set; }
        public string path { get; set; }
        public string name { get; set; }
    }
}
