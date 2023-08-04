using OnionArchitecture.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Abstractions.Services.Project
{
    public interface IProductService
    {
        Task<ResultInfo> CreateProductAsync(CreateProductDto createProductDto);
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<ResultInfo> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<ResultInfo> DeleteProductAsync(int id);
    }
}

