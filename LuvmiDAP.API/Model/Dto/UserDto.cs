using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LuvmiDAP.API.Model.Dto
{
    public class UserDto
    {
        [Required]
        public string  Username { get; set; }
        [Required]
        [StringLength(8,MinimumLength =4 ,ErrorMessage ="you must submit password btw 4 and 8")]
        public string Password { get; set; }
    }
}
