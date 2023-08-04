using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Azure;
using OnionArchitecture.Application.Abstractions.DB.Tools;
using OnionArchitecture.Application.Abstractions.Repositories;
using OnionArchitecture.Application.Abstractions.Services.Project;
using OnionArchitecture.Application.DTOs.Product;
using OnionArchitecture.Application.Helpers;

namespace OnionArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICommonRepository commonRepository;

        public ProductsController(IProductService productService, ICommonRepository commonRepository, IEFDatabaseTool eFDatabaseTool)
        {
            _productService = productService;
            this.commonRepository = commonRepository;
        }
        [HttpGet]
        public async Task<List<ProductDto>> GetAllProducts()
        {
            var serviceProvider = ServiceProviderHelper.ServiceProvider;
            var commonRepositoryService = serviceProvider.GetRequiredService<ICommonRepository>();
            return null;
            //var Result = await _productService.GetAllProductsAsync();
            //return Result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var Result = await _productService.CreateProductAsync(createProductDto);
            return Result.AsObjectResult();

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var result = await _productService.UpdateProductAsync(updateProductDto);
            return result.AsObjectResult();
        }

        [HttpDelete("{Id}")]
        public async Task<ResultInfo> DeleteProduct(int Id) 
        {
            return await _productService.DeleteProductAsync(Id);
        }

        [HttpGet("{Id}")]
        public async Task<ProductDto> GetProductById(int Id)
        {
            return await _productService.GetProductByIdAsync(Id);
        }
    }
}
