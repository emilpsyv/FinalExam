
using EmilEamm.DAL;
using EmilEamm.ViewModels.Member;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EmilEamm.Controllers
{
    public class HomeController(ExamContext _context) : Controller
    {


        public async Task<ActionResult> Index()
        {
            var data = await _context.Members.Select(m => new GetMemberVM
            {
                Id = m.Id,
                Name = m.Name,
                JobTitle = m.JobTitle,
                Description = m.Description,
              
                ImgUrl = m.ImgUrl
            }
            ).ToListAsync();
            return View(data);
        }

    }
}
