using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Core.Entities
{
    public class Cart:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Imgpath { get; set; }
    }
}
