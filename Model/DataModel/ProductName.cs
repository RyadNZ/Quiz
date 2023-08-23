using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel
{
    public class ProductName
    {
        public int ProductNameId { get; set; }
        public string LanguageCode { get; set; }
        public string Text { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
