using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsServer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsServer.Infrastructure
{
    public class ProductsRepository: IProductsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductsRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            var res = await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.ProductCategory)
                .ToListAsync();
            return _mapper.Map<List<Domain.Product>>(res);
        }
    }
}
