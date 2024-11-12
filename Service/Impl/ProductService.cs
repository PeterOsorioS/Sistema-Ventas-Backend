using Data.Repository.Interface;
using Entities.Models;
using Exceptions;
using Mapster;
using Service.DTOs;
using Service.Interface;


namespace Service.Impl
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void DeleteProduct(int id)
        {
            var productDB = _productRepository.GetById(id);
            if (productDB == null)
            {
                throw new BadRequestException("El producto no existe.");
            }
            _productRepository.Remove(productDB);
            _productRepository.Save();
        }

        public ProductDTO GetProduct(int id)
        {
            var productDB = _productRepository.GetById(id);
                if (productDB == null)
                {
                    throw new BadRequestException("El producto no existe.");
                }
            var product = productDB.Adapt<ProductDTO>();
            return product;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var productsDB = _productRepository.GetAll(includeProperties: "Category");
            if (!productsDB.Any())
            {
                throw new BadRequestException("No se encuentran productos registrados.");
            }
            var products = productsDB.Adapt<IEnumerable<ProductDTO>>();
            return products;
        }

        public void UpdateProduct(int id, ProductDTO productDTO)
        {
            var producte = _productRepository.GetById(id);
            if (producte == null) 
            {
                throw new BadRequestException("El producto no existe.");
            }
            var product = productDTO.Adapt<Product>();
            product.Id = id;

            _productRepository.Update(product);
            _productRepository.Save();
        }
    }
}
