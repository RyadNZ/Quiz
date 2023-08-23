using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
    }
}
