using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsServer.Infrastructure.Entities
{
    internal class ProductCategoryEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
