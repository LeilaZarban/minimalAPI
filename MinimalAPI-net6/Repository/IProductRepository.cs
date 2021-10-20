using MinimalApI_net6.Models;

namespace MinimalApI_net6.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product? GetById(int id);
        void Create(Product product);
        Product Update(Product product);
        void Delete(int id);
    }
}
