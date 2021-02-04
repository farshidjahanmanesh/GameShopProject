using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameShopProject.Components
{
    public class ProductsViewComponent : ViewComponent
    {
        private readonly IProductService productService;

        public ProductsViewComponent(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products=await productService.GetProductForIndexPage();
            return View(products);
        }
    }
}
