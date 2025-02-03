using ProductsServer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsServer.Application
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>> GetCategoriesAsync();
    }
}
