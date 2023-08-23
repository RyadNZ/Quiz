using Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IProductRepository
    {
        Product GetById(int ProductId);
        IEnumerable<Product> GetAll();        
        IEnumerable<Product> GetProducts(int page, int pageSize, string productName, string category);        

        IEnumerable<Image> GetProductImages(int productId);
        Image GetProductImageById(int productId, int imageId);
        void Add(Product product);
        void Update(Product product);
        void Delete(int ProductId);
        void AddImageToProduct(int productId, Image img);
        void RemoveImageFromProduct(int productId, int imageId);
    }
    public interface IProductNameRepository
    {
        ProductName GetById(int ProductNameId);
        IEnumerable<ProductName> GetByProductId(int ProductId);
        ProductName GetSpecificLanguageByProductId(int ProductId, string LanguageCode);
        IEnumerable<ProductName> GetAll();
        void Add(ProductName productName);
        void Update(ProductName productName);
        void Delete(int ProductNameId);
    }
    public interface IImageRepository
    {
        Image GetById(int ImageId);
        IEnumerable<Image> GetImagesByProductId(int ProductId);
        IEnumerable<Image> GetAll();
        void Add(Image image);
        void Update(Image image);
        void Delete(int ImageId);
        void DeleteProductImages(int ProductId);
    }
    public interface ICategoryRepository
    {
        Category GetById(int CategoryId);
        IEnumerable<Category> GetAll();
        void Add(Category category);
        void Update(Category category);
        void Delete(int CategoryId);
    }
    public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> GetByProductID(int ProductId);
        IEnumerable<ProductCategory> GetByCategoryId(int CategoryId);
        void Add(ProductCategory productCategory);
        void Update(ProductCategory productCategory);
    }
}
