using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product GetProduct(int id)
        {
            return _productRepository.GetById(id);
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }
        public IEnumerable<Image> GetProductImages(int productId)
        {
            return _productRepository.GetProductImages(productId);
        }
        public Image GetProductImageById(int productId, int imageId)
        {
            return _productRepository.GetProductImageById(productId, imageId);
        }
        public IEnumerable<Product> GetProducts(int page, int pageSize, string productName, string category)
        {
            return _productRepository.GetProducts(page, pageSize, productName, category);
        }
        public void Add(Product product)
        {
            _productRepository.Add(product);
        }
        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
        public void AddImageToProduct(int productId, Image img)
        {
            _productRepository.AddImageToProduct(productId, img);
        }
        public void RemoveImageFromProduct(int productId, int imageId)
        {
            _productRepository.RemoveImageFromProduct(productId, imageId);
        }
    }
    public class ProductNameService
    {
        private readonly IProductNameRepository _productNameRepository;
        public ProductName GetById(int id)
        {
            return _productNameRepository.GetById(id);
        }
        public IEnumerable<ProductName> GetByProductId(int ProductId)
        {
            return _productNameRepository.GetByProductId(ProductId);
        }
        public ProductName GetSpecificLanguageByProductId(int ProductId, string LanguageCode)
        {
            return _productNameRepository.GetSpecificLanguageByProductId(ProductId, LanguageCode);
        }
        public IEnumerable<ProductName> GetAll()
        {
            return _productNameRepository.GetAll();
        }
        public void Add(ProductName productName)
        {
            _productNameRepository.Add(productName);
        }
        public void Update(ProductName productName)
        {
            _productNameRepository.Update(productName);
        }
        public void Delete(int ProductNameId)
        {
            _productNameRepository.Delete(ProductNameId);
        }
    }    

}
