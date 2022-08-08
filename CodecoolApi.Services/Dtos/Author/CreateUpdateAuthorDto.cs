using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Services.Dtos.Author
{
    public class CreateUpdateAuthorDto
    {
        [Required]
        [MinLength(3), MaxLength(40)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
