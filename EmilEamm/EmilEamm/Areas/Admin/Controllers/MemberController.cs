using EmilEamm.DAL;
using EmilEamm.ViewModels.Member;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmilEamm.Models;
using Microsoft.EntityFrameworkCore;
using EmilEamm.Extension;
namespace EmilEamm.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController(ExamContext _context, IWebHostEnvironment _env) : Controller
    {

        public async Task<ActionResult> Index()
        {
            var data = await _context.Members.Select(m => new GetAdminMemberVM
            {
                Id = m.Id,
                Name = m.Name,
                JobTitle = m.JobTitle,
                Description = m.Description,
                CreatTime = m.CreatTime,
                ImgUrl = m.ImgUrl
            }
            ).ToListAsync();
            return View(data);
        }



        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateMemberVM cardVM)
        {
            string FileName = await cardVM.Image.SaveFileAsync(Path.Combine(_env.WebRootPath, "imgs", "card"));

            Member card = new Member
            {
                ImgUrl = Path.Combine("imgs", "card", FileName),
                Name = cardVM.FullName,
                Description = cardVM.Description,
                JobTitle = cardVM.JobTitle,
                CreatTime = DateTime.Now,
            };
            await _context.Members.AddAsync(card);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        public async Task<ActionResult> Edit(int id, IFormFile image)
        {
            var data = await _context.Members.FirstOrDefaultAsync(x => x.Id == id);
            EditMemberVM memberVM = new EditMemberVM
            {
                FullName = data.Name,
                JobTitle = data.JobTitle,
                Description = data.Description,
                Image = image
            };
            return View(memberVM);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, EditMemberVM vm)
        {
            var data = await _context.Members.FirstOrDefaultAsync(x => x.Id == id);
            string FileName = await vm.Image.SaveFileAsync(Path.Combine(_env.WebRootPath, "imgs", "card"));

            data.Name = vm.FullName;
            data.Description = vm.Description;
            data.JobTitle = vm.JobTitle;
            data.ImgUrl = Path.Combine("imgs", "card", FileName);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<ActionResult> Delete(int? id)
        {
            var data = await _context.Members.FirstOrDefaultAsync(x => x.Id == id);

            _context.Members.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }









}

