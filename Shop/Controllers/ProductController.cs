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
    public IActionResult Index()
    {
      return View(repository.GetProductList());
    }

    [HttpPost]
    [ActionName("Delete")]
    public IActionResult Delete(int id)
    {
      repository.RemoveProduct(id);
      return View("~/Views/Product/Index.cshtml");
    }
  }
}