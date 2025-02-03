using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsServer.Domain;
using ProductsServer.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsServer.Infrastructure
{
    public class ProductCategoryRepository: IProductCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductCategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategoriesAsync()
        {
            var categories = await _context.ProductCategories.ToListAsync();
            return _mapper.Map<List<Domain.ProductCategory>>(categories);
         
        }
    }
}
