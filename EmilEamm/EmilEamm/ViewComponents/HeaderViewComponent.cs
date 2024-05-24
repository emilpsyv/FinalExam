using EmilEamm.DAL;
using Microsoft.AspNetCore.Mvc;

namespace EmilEamm.ViewComponents
{
    public class HeaderViewComponent(ExamContext _context) : ViewComponent
    {
      
        public async Task<IViewComponentResult> InvokeAsync()
        {
           

            return View();
        }
    }
}

