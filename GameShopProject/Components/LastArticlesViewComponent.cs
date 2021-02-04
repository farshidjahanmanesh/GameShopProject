using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameShopProject.Components
{
    public class LastArticlesViewComponent : ViewComponent
    {
        public LastArticlesViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
