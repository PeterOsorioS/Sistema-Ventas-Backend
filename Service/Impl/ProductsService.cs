using Data.Repository.Interface;
using Entities.Models;
using Exceptions;
using Mapster;
using Service.DTOs;
using Service.Interface;


namespace Service.Impl
{
    public class ProductsService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductDTO CreateProduct(ProductDTO productDTO)
        {
            var product = productDTO.Adapt<Product>();
            _productRepository.Add(product);
            _productRepository.Save();

            return productDTO;
        }

        public async Task DeleteProduct(int id)
        {
            var productDB = _productRepository.GetById(id);
            if (productDB == null)
            {
                throw new BadRequestException("El producto no existe.");
            }
            await _productRepository.Remove(productDB);
            await _productRepository.SaveAsync();
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

        public IEnumerable<ProductDTO> GetAllProducts()
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
