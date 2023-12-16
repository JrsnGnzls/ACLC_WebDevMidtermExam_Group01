using ACLC_WebDevMidtermExam_Group01.Models;
using Microsoft.AspNetCore.Mvc;

namespace ACLC_WebDevMidtermExam_Group01.Controllers
{
    public class UserloginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(Account user)
        { 
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}
