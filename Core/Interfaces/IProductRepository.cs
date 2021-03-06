using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository
    {

        Task<ProductEntity> GetProductByIdAsync(int id);
        Task<IReadOnlyList<ProductEntity>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrandEntity>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductTypeEntity>> GetProductTypesAsync();

    }
}
