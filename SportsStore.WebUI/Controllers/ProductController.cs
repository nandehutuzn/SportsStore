using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository _repository;
        public int PageSize = 4;

        public ProductController(IProductsRepository productsRepository)
        {
            this._repository = productsRepository;
        }

        // GET: Product
        public ActionResult List(int page=1)
        {
            ProductsListViewModel model = new ProductsListViewModel()
            {
                Products = _repository.Products.OrderBy(p => p.ProductID)
                                                    .Skip((page - 1) * PageSize)
                                                    .Take(PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.Products.Count(),
                },
            };

            return View(model);
        }
    }
}