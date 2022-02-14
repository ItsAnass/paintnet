using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductEntity : BaseEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductTypeEntity ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrandEntity ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}
