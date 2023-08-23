using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductDescription { get; set; }
        public string InventoryNumber { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductCost { get; set; }

        public ICollection<Image> ProductImages { get; set; }
        public ICollection<ProductName> ProductNames { get; set; }
        public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
    }
}
