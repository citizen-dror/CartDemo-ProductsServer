using ProductsServer.Domain;
using ProductsServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsServer.Application
{
    public class ProductCategoryService: IProductCategoryService
    {
        public IProductCategoryRepository _repository;

        public ProductCategoryService(IProductCategoryRepository repo)
        {
            this._repository = repo;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategoriesAsync()
        {
            return await this._repository.GetCategoriesAsync();
        }
    }
}
