using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.ProductServices;
using System.Linq;
using System.Threading.Tasks;

namespace GameShopProject.Components
{
    public class BestViewerProductsViewComponent : ViewComponent
    {
        private readonly IProductService productService;

        public BestViewerProductsViewComponent(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await productService.GetProductForIndexPage();
            return View(products.Take(5).ToList());
        }
    }
}
