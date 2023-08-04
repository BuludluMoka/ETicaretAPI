using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using OnionArchitecture.Application.Abstractions.Services.Project;
using OnionArchitecture.Application.DTOs.Product;
using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Services.Project
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            IQueryable<Product> products = _productReadRepository.GetAll();
            var ProductDto = _mapper.Map<List<ProductDto>>(await products.ToListAsync());
            return ProductDto;
        }
        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }
        public async Task<ResultInfo> CreateProductAsync(CreateProductDto createProductDto)
        {
            var Product = _mapper.Map<Product>(createProductDto);
            await _productWriteRepository.AddAsync(Product);
            return await _productWriteRepository.SaveAsync();
        }

        public async Task<ResultInfo> DeleteProductAsync(int id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            if (product is null) return ResultInfo.NotFound;
            bool ProductIsRemoved = _productWriteRepository.Remove(product);
            if (!ProductIsRemoved) return ResultInfo.UnexpectedError;
            return await _productWriteRepository.SaveAsync();
        }
        public async Task<ResultInfo> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            Product product = _mapper.Map<Product>(updateProductDto);
            _productWriteRepository.Update(product);
            return await _productWriteRepository.SaveAsync();

        }
    }
}
