using AppDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppDemo.Controllers
{
    public class AuthorController : Controller
    {
        private ApplicationDbContext context;
        public AuthorController(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public IActionResult Detail(int id)
        {
            var author = context.Author.Include(c => c.Book);      //Country - Brand: 1 - M
                                      
            /* Note:
             * Nếu 2 bảng có kết nối trực tiếp (đi thẳng) thì dùng hàm Include
             * Nếu 2 bảng có kết nối gián tiếp (đi vòng) thông qua bảng trung gian thì dùng hàm ThenInclude
             */
            return View(author);
        }
    }
}
