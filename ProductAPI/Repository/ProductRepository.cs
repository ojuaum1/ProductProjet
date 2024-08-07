using ProductAPI.Contexts;
using ProductAPI.Domains;
using ProductAPI.Interfaces;

namespace ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository()
        {
            _context = new Context();
        }

        public List<Product> GetAll()
        {
            try
            {
                return _context.Product.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Create(Product product)
        {
            try
            {
                _context.Product.Add(product);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Guid id, Product product)
        {
            try
            {
                Product findProduct = _context.Product.Find(id)!;

                if (findProduct != null)
                {
                    findProduct.Name = product.Name;
                    findProduct.Price = product.Price;
                }

                _context.Product.Update(findProduct!);

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Product SearchById(Guid id)
        {
            try
            {
                return _context.Product.Find(id!);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                Product findProduct = _context.Product.Find(id!);

                if (findProduct != null)
                {
                    _context.Product.Remove(findProduct);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
