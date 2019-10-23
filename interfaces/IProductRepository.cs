using System;
using System.Collections.Generic;
using ProductApi.Models;

namespace ProductApi.Interfaces
{
    public interface IProductRepository
    {
        List<Product> All();
        Product Find(int id);
        String Insert(Product item);
        String Update(int id, Product item);
        String Delete(int id);
    }
}