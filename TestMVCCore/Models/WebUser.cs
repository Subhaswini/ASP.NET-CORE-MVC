using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TestMVCCore.Models
{
    public class WebUser
    {
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

/*      [Required]
        [EmailAddress]
        public string MailAddress { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public bool IsActive { get; set; }

        [MaxLength(10)]
        public string Description { get; set; }*/
        public string Country { get; set; }
    }
}
