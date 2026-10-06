using Microsoft.AspNetCore.Mvc;

namespace baitaptuan5.Controllers
{
    public class BookController : Controller
    {
        // Đường dẫn: /Book hoặc /Book/Index
        public IActionResult Index()
        {
            return Content("Danh sach sach (Book Index)");
        }

        // Đường dẫn: /Book/Detail/1
        public IActionResult Detail(int id)
        {
            return Content($"Chi tiet sach co ID = {id}");
        }

        // Đường dẫn: /Book/Create
        public IActionResult Create()
        {
            return Content("Trang tao moi sach (Book Create)");
        }
    }
}