using AutoMapper;
using ECommerce.Application.Contracts;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepo _repo;

        public ProductService(IMapper mapper, IProductRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var result = await _repo.GetAllProductsAsync();
            var products = _mapper.Map<List<Product>, List<ProductDto>>(result);
            return products;
        }

        

    }
}
