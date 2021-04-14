using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Customer
    {
     
        [Key]
        public int ?Id { get; set; }

        [Required]
        [MaxLength(15,ErrorMessage ="First Name can only be 15 character")]
        public String FirstName { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Last Name can only be 15 character")]
        public String LastName { get; set; }

        [MaxLength(20, ErrorMessage = "Email Name can only be 20 character")]
        public String Email { get; set; }

        [MaxLength(10, ErrorMessage = "Contact No can only be 10 character")]
        public String ContactNo { get; set; }
    }
}
