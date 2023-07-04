using ETicaretAPI.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.Services.Project
{
    public interface IProductService
    {
        Task CreateProductAsync(CreateProductDto createOrder);
        Task<ProductDto> GetAllProductsAsync(int page, int size);
        Task<ProductDto> GetProductByIdAsync(string id);
        Task DeleteProductAsync(string id);
    }
}
