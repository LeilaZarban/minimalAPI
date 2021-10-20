using MinimalApI_net6.Repository;
using MinimalApI_net6.Models;

namespace MinimalApI_net6.Repository
{
   public class ProductRepository:IProductRepository
    {
        private Dictionary<int, Product> _products = new();
        public List<Product> GetAll()
        {
            return _products.Values.ToList();
        }
        public Product? GetById(int id)
        {
            return _products.GetValueOrDefault(id);
        }
        public void Create(Product product)
        {
            if (GetById(product.Id) is not null)
            {
                throw new Exception("This product is already exist");
            }
            else
            {
                _products[product.Id] = product;
            }
        }
        public Product Update(Product product)
        {
            if (GetById(product.Id) is null)
            {
                throw new ArgumentException("expected product is not found");
            }
            else
            {
                _products[product.Id] = product;
            }
            return _products[product.Id];
        }
        public void Delete(int id)
        {
            if (GetById(id) is null)
            {
                throw new ArgumentException("expected product is not found");
            }
            else
            {
                _products.Remove(id);
            }
        }

    }
}
