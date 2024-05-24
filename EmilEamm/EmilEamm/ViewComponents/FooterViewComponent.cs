using EmilEamm.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmilEamm.ViewComponents
{
    public class FooterViewComponent(ExamContext _context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Dictionary<string, string> settings = await _context.Setting.ToDictionaryAsync(s => s.Key, s => s.Value);
            return View(settings);
        }
    }
}
