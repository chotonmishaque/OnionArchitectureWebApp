using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnionArchitecture.Data
{
    [Index(nameof(Name), IsUnique = true)]
    public class Department : BaseEntity
    {
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(55)]
        public string Name { get; set; }
    }
}
