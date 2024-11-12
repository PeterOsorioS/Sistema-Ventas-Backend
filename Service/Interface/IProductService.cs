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
        public void CreateProduct(ProductDTO productDTO);
        public ProductDTO GetProduct(int id);
        public IEnumerable<ProductDTO> GetProducts();
        public void UpdateProduct(int id,ProductDTO product);
        public void DeleteProduct(int id);
    }
}
