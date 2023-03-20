using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowProject.DomainModels
{
    public class User
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public int Email { get; set; }
        public int PasswordHash { get; set; }
        public int Name { get; set; }
        public int Mobile { get; set; }
        public int IsAdmin { get; set; }

    }
}
