using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameShopProject.Components
{
    public class BestArticlesViewComponent : ViewComponent
    {
        public BestArticlesViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
