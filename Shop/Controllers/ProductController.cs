using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Models;
using Shop.Repositories;
using Shop.Interfaces;

namespace Shop.Controllers
{
  public class ProductController : Controller
  {
    private IProductRepository repository;

    public ProductController(IProductRepository repository)
    {
      this.repository = repository;
    }


    [HttpGet]
    public IActionResult Products()
    {
      return View(repository.GetProductList());
    }

    [HttpDelete]
    [ActionName("Delete")]
    public void Delete(int id)
    {
      repository.RemoveProduct(id);
    }
  }
}