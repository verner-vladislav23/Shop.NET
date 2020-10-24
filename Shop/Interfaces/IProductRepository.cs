using System;
using System.Collections;
using System.Collections.Generic;
using Shop.Models;

namespace Shop.Interfaces
{
  public interface IProductRepository
  {
    IEnumerable<Product> GetProductList();
    Product GetProduct(int id);
    Product CreateProduct(Product item);
    void RemoveProduct(int id);
    bool UpdateProduct(Product item);
  }
}