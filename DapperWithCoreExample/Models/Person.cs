using System.ComponentModel.DataAnnotations;

namespace DapperWithCoreExample.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter {0}")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.PostalCode)]
        public string? ZipCode { get; set; }
        public string? Adresse { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
