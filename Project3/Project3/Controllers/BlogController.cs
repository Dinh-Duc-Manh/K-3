using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project3.Data;
using X.PagedList;

namespace Project3.Controllers
{
    public class BlogController : Controller
    {
        private readonly Sem3DBContext _context;

        public BlogController(Sem3DBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? type, int? page)
        {
            int pageLimit = 4;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var news = await _context.News.OrderByDescending(n => n.NewsId).ToPagedListAsync(pageNumber, pageLimit);

            if (!String.IsNullOrEmpty(type))
            {
                news = await _context.News.Where(n => n.NewsType.Contains(type)).OrderByDescending(n => n.NewsId).ToPagedListAsync(pageNumber, pageLimit);
            }
            return View(news);
        }

        public async Task<IActionResult> Details(int? id, int? page)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News.FirstOrDefaultAsync(n => n.NewsId == id);
            int pageLimit = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var comment = await _context.Comments.OrderByDescending(c => c.CommentId).ToPagedListAsync(pageNumber, pageLimit);

            if (news == null)
            {
                return NotFound();
            }

            ViewData["ne_title"] = news.Title;
            ViewData["ne_LongContent"] = news.LongContent;
            return View(comment);
        }
    }
}
