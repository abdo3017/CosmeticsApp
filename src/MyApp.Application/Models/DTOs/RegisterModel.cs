using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.DTOs
{
    public class RegisterModel
    {

        [StringLength(50)]
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(256)]
        public string Password { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

    }
}
