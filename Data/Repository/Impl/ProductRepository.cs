using Data.Context;
using Data.Repository.Interface;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Impl
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Update(Product product)
        {
            var productDB = _db.products.FirstOrDefault(p => p.Id == product.Id);
            if (productDB != null) 
            { 
                productDB.Name = product.Name;
                productDB.Description = product.Description;
                productDB.CodeQR = product.CodeQR;
                productDB.Price = product.Price;
                productDB.IdCategory = product.IdCategory;
                productDB.Stock = product.Stock;
                product.State = product.State;
            }
        }
    }
}
