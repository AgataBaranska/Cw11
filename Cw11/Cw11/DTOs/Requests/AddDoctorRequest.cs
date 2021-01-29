using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.DTOs.Requests
{
    public class AddDoctorRequest
    {

        [Required(ErrorMessage = "Musisz podać imie")]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Musisz podać nazwisko")]
        [MaxLength(100)]
        public string LastName { get; set; }
 
        public string Email { get; set; }


    }
}
