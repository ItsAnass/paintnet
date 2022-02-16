using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<ProductEntity> _productsRepo;
        private readonly IGenericRepository<ProductEntity> _productBrandRepo;
        private readonly IGenericRepository<ProductEntity> _productTypeRepo;

        public ProductsController(IGenericRepository<ProductEntity> productsRepo, IGenericRepository<ProductEntity> productBrandRepo, IGenericRepository<ProductEntity> productTypeRepo)
        {
            _productsRepo = productsRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
        }


        [HttpGet]
        public async Task<ActionResult<List<ProductEntity>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();

            var products = await _productsRepo.ListAsync(spec);

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductEntity>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            return await _productsRepo.GetEntityWithSpec(spec);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrandEntity>>> GetProductBrands()
        {
            return Ok( await _productBrandRepo.ListAllAsync()); 
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductTypeEntity>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }


    }
}
