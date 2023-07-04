using ETicaretAPI.Application.Abstractions.Services.Project;
using ETicaretAPI.Application.DTOs.Product;
using ETicaretAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Services.Project
{
    public class ProductService : IProductService
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public Task CreateProductAsync(CreateProductDto createOrder)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetAllProductsAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProductByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
