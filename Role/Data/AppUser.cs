using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Role.Data
{
    public class AppUser : IdentityUser<string>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public override string Id { get; set; }
    }
}