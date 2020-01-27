using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Application
        {


            public int Id { get; set; }

            [StringLength(60, MinimumLength = 3)]
            [Required]
            public string Email { get; set; }

            [StringLength(60, MinimumLength = 3)]
            [Required]
            public string UserName { get; set; }

            [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
            [Required]
            [StringLength(30)]
            public string Password { get; set; }

            public bool isAdmin { get; set; }


        }
    

}
