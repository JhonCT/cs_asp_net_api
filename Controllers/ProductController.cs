using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Services;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private ProductRepository productRepository = new ProductRepository();
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productRepository.All();
        }

        [HttpPost]
        public String Post(Product product)
        {
            return productRepository.Insert(product);
        }

        [HttpPut("{id}")]
        public String Put(int id, Product product)
        {
            return productRepository.Update(id, product);
        }

        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return productRepository.Delete(id);
        }
    }
}
