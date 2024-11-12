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
        public ProductDTO CreateProduct(ProductDTO productDTO);
        public ProductDTO GetProduct(int id);
        public IEnumerable<ProductDTO> GetAllProducts();
        public ProductDTO UpdateProduct(int id,ProductDTO product);
        public Task DeleteProduct(int id);
    }
}
