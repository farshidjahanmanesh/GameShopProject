using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameShopProject.Components
{
    public class LastNewsViewComponent : ViewComponent
    {
        public LastNewsViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
