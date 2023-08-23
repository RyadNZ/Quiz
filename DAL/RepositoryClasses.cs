using Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _context;
        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }
        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.OrderBy(p => p.ProductPrice).ToList();
        }
        public IEnumerable<Product> GetProducts(int page, int pageSize, string productName, string category)
        {
            return
            _context.Products
                .Where(p => p.ProductNames
                    .Any(pn => pn.Text == productName || productName == ""))
                .Where(p => p.ProductCategories
                    .Any(pc => pc.Category.CategoryName == category || category == ""))
                .Skip((page - 1) * pageSize).Take(pageSize)
                .ToList();
        }
        public IEnumerable<Image> GetProductImages(int productId)
        {            
            var product = GetById(productId);
            if (product == null)
                throw new ArgumentException("not found");
            else
                return
                    product.ProductImages.ToList();                
        }
        public Image GetProductImageById(int productId, int imageId)
        {
            var product = GetById(productId);
            if (product == null)
                throw new ArgumentException("not found");
            else
                return
                    product.ProductImages.Where(p => p.ImgId == imageId).FirstOrDefault();
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            else
            {
                _context.Products.Update(product);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
        public void AddImageToProduct(int productId, Image img)
        {
            var product = GetById(productId);
            product.ProductImages.Add(img);
        }
        public void RemoveImageFromProduct(int productId, int imageId)
        {
            var image = GetProductImageById(productId, imageId);
            var product = GetById(productId);
            product.ProductImages.Remove(image);
            _context.Images.Remove(image);
            _context.SaveChanges();
        }
    }
    public class ProductNameRepository : IProductNameRepository
    {
        private readonly AppDBContext _context;
        public ProductNameRepository(AppDBContext contxt)
        {
            _context = contxt;
        }
        public ProductName GetById(int id)
        {
            return _context.ProductNames.Find(id);
        }
        public IEnumerable<ProductName> GetByProductId(int ProductId)
        {
            return _context.ProductNames.Where(a => a.ProductId == ProductId).ToList();
        }
        public ProductName GetSpecificLanguageByProductId(int ProductId, string LanguageCode)
        {
            return _context.ProductNames
                .Where(a => a.ProductId == ProductId && a.LanguageCode == LanguageCode)
                .FirstOrDefault();
        }
        public IEnumerable<ProductName> GetAll()
        {
            return _context.ProductNames.ToList();
        }
        public void Add(ProductName productName)
        {
            _context.Add(productName);
            _context.SaveChanges();
        }
        public void Update(ProductName productName)
        {
            if (productName == null)
                throw new ArgumentNullException(nameof(productName));
            else
            {
                _context.Update(productName);
                _context.SaveChanges();
            }
        }
        public void Delete(int ProductNameId)
        {
            var productName = GetById(ProductNameId);
            if (productName != null)
            {
                _context.ProductNames.Remove(productName);
                _context.SaveChanges();
            }
        }
    }
    public class ImageRepository : IImageRepository
    {
        private readonly AppDBContext _context;
        public ImageRepository(AppDBContext context)
        {
            _context = context;
        }
        public Image GetById(int id)
        {
            return _context.Images.Find(id);
        }
        public IEnumerable<Image> GetImagesByProductId(int ProductId)
        {
            return _context.Images.Where(a => a.ProductId == ProductId).ToList();
        }       
        public IEnumerable<Image> GetAll()
        {
            return _context.Images.ToList();
        }
        public void Add(Image image)
        {
            _context.Images.Add(image);
            _context.SaveChanges();
        }
        public void Update(Image image)
        {
            _context.Images.Update(image);
            _context.SaveChanges();
        }
        public void Delete(int ImageId)
        {
            var image = GetById(ImageId);
            if (image != null)
            {
                _context.Images.Remove(image);
                _context.SaveChanges();
            }
        }
        public void DeleteProductImages(int ProductId)
        {
            var images = GetImagesByProductId(ProductId);
            foreach (var image in images)
                _context.Images.Remove(image);
            _context.SaveChanges();
        }
        public void DeleteProductImage(int productId, int imageId)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            
        }
    }
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _context;
        public Category GetById(int id)
        {
            return _context.Categories.Find(id);
        }
        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var category = GetById(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDBContext _context;
        public IEnumerable<ProductCategory> GetByProductID(int ProductId)
        {
            return _context.ProductCategories.Where(a => a.ProductId == ProductId).ToList();
        }
        public IEnumerable<ProductCategory> GetByCategoryId(int CategoryId)
        {
            return _context.ProductCategories.Where(a => a.CategoryId == CategoryId).ToList();
        }
        public void Add(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            _context.SaveChanges();
        }
        public void Update(ProductCategory productCategory)
        {
            _context.ProductCategories.Update(productCategory);
            _context.SaveChanges();
        }
    }
}
