using System;
using System.Collections;
using System.Collections.Generic;
using Shop.Models;
using Shop.Interfaces;

namespace Shop.Repositories
{
  public class ProductRepository : IProductRepository
  {
    private string DEFAULT_IMAGE_URL =
      "https://www.91-img.com/pictures/97744-v1-apple-iphone-7-mobile-phone-large-1.jpg?tr=q-60";
    
    private List<Product> products = new List<Product>();
    private int _nextId = 1;
    
    public ProductRepository ()
    {
      CreateProduct(new Product
      {
        Name = "IPhone 12 MINI",
        Price = 75000,
        Image = DEFAULT_IMAGE_URL
      });
      CreateProduct(new Product
      {
        Name = "IPhone 8 Plus",
        Price = 35000,
        Image = DEFAULT_IMAGE_URL
      });
    }
    
    public IEnumerable<Product> GetProductList()
    {
      return products;
    }
    
    public Product GetProduct(int productId)
    {
      return products.Find(product => product.Id == productId);
    }
    
    public Product CreateProduct(Product product)
    {
      if (product == null)
      {
        throw new ArgumentNullException("item");
      }
    
      product.Id = _nextId++;
      products.Add(product);
    
      return product;
    }
    
    
    public bool UpdateProduct(Product product)
    {
      if (product == null)
      {
        throw new ArgumentNullException("item");
      }
      
      var index = products.FindIndex(p => p.Id == product.Id);
      if (index == -1)
      {
        return false;
      }
      
      products.RemoveAt(index);
      products.Add(product);
      return true;
    }
    
    
    public void RemoveProduct(int id)
    {
      products.RemoveAll(p => p.Id == id);
    }
  }
}