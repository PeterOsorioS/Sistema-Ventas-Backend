using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IProductService
    {
        public CreateProductDTO CreateProduct(CreateProductDTO productDTO);
        public ProductDTO GetProduct(int id);
        public IEnumerable<ProductDTO> GetAllProducts();
        public UpdateProductDTO EditProduct(int id, UpdateProductDTO productDTO);
        public Task DeleteProduct(int id);
    }
}
