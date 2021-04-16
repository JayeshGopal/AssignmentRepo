using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Contact
    {
        [Key]
        public int? ContactId { get; set; }
        
        [Required]
        [MaxLength(15)]
        public String FirstName { get; set; }

        [MaxLength(15)]
        public String LastName { get; set; }

        [MaxLength(20)]
        [DataType(DataType.EmailAddress,ErrorMessage ="Invalid Email ID")]
        public String Email { get; set; }

        [MaxLength(10)]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Incorrect Mobile Number")]
        public String PhoneNo { get; set; }

        [Required]
        [MaxLength(10)]
        public String MobileNo { get; set; }
    }
}
