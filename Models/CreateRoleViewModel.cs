using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class CreateRoleViewModel
    {
           [Required]
            public string RoleName { get; set; }
        
    }
}
