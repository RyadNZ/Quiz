using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel
{
    public class ProductCategory
    {
        public virtual Product Product { get; set; }
        public int? ProductId { get; set; }
        public virtual Category Category { get; set; }
        public int? CategoryId { get; set; }
    }
}
