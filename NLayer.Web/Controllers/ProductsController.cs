﻿using Microsoft.AspNetCore.Mvc;
using NLayer.Service.Services.Abstract;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View((await _service.GetProductsWithCategoryAsync()).Data);
        }
    }
}
