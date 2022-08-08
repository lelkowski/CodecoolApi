using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecoolApi.Data.Models
{
    public class EducationalMaterialType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public ICollection<EducationalMaterial> Materials { get; set; }
        public EducationalMaterialType()
        {
            Materials = new List<EducationalMaterial>();
        }

    }
}
