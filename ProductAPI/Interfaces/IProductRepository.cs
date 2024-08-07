using ProductAPI.Domains;

namespace ProductAPI.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        Product SearchById(Guid id);

        void Create(Product newProduct);

        void Update(Guid id, Product product);

        void Delete(Guid id);
    }
}
