using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DBOperations
    {
        public ProductContext context = new ProductContext();
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            products = context.Product.ToList();

            foreach (var p in products)
            {
                p.Category = context.Category.FirstOrDefault(x => x.categoryId == p.categoryId);
            }
            return products;
        }
        public bool AddProduct(Product product)
        {
            Category? category = context.Category.FirstOrDefault(p => p.categoryId == product.categoryId);
            product.Category = category;
            context.Product.Add(product);
            context.SaveChanges();
            return true;
        }
    }
}
