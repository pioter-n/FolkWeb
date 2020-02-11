using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Role.Areas.DancesType.Models
{
    public class DanceTypes
    {
        [Key]
        public int Id { get; set; }
        public string Types { get; set; }
    }
}
