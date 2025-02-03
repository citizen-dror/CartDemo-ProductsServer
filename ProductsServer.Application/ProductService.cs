using ProductsServer.Domain;
using ProductsServer.Infrastructure;

namespace ProductsServer.Application
{
    public class ProductService :IProductService
    {
        public IProductsRepository _repository;

        public ProductService(IProductsRepository repo)
        {
            this._repository = repo;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await this._repository.GetProductsByCategoryAsync(categoryId);
        }
    }
}
