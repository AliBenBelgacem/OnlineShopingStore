using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Entities
{
    public class User
    {
        [Key]
        public string UserID { get; set; }
        public string Password { get; set; }
    }
}
