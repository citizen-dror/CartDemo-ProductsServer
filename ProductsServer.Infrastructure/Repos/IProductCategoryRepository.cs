using ProductsServer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsServer.Infrastructure
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetCategoriesAsync();
    }
}
