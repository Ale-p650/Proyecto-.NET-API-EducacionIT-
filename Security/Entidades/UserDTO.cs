using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Entidades
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string[] Roles { get; set; }


    }
}
