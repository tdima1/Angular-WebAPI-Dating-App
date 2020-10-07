using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.DTOs
{
   public class UserForRegisterDTO
   {
      [Required]
      public string Username { get; set; }

      [Required]
      [StringLength(8, MinimumLength = 4, ErrorMessage ="Pass between 4-8")]
      public string Password { get; set; }
   }
}
