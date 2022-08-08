using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Services.Dtos.EducationalMaterialType
{
    public class TypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public List<string> Materials { get; set; }
    }
}
