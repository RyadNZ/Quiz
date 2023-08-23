using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel
{
    public class Image
    {
        public int ImgId { get; set; }
        public string ImgUrl { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
