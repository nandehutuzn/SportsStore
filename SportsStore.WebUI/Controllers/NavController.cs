﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductsRepository _repository;

        public NavController(IProductsRepository repo)
        {
            _repository = repo;
        }

        // GET: Nav
        public PartialViewResult Menu(string category = null)  //呈现分部视图
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = _repository.Products
                .Select(x => x.Category)
                .Distinct().OrderBy(x => x);
            return PartialView(categories);
        }
    }
}