using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Views
{
    public class CreateRoleViewModel
    {
          [Required]
            public string RoleName { get; set; }
        
    }
}
