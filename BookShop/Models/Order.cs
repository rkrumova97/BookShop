using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a book")]
        public int BookId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please select a name")]
        public string ClientName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please select a book")]
        public string Street { get; set; }

        public string State { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please select a book")]
        public string Country { get; set; }

        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "Please select a book")]
        public string Zip { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please select a book")]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please select a book")]
        public string Email { get; set; }

    }
}
