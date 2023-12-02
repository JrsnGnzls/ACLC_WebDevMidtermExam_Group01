using ACLC_WebDevMidtermExam_Group01.DataConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace ACLC_WebDevMidtermExam_Group01.Controllers
{
    public class FormController : Controller
    {
        private readonly MySqlDbContext _context;
        public FormController(MySqlDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(string id)
        {
            var joborder = from p in _context.form
                           select p;
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    int pId = Convert.ToInt32(id);
                    joborder = joborder.Where(p => p.id == pId);
                }
                catch (FormatException ee)
                {

                }

            }
            return View(await joborder.ToListAsync());
        }
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]

    public ActionResult Create( Models.joborder)
    {
        
        return View();
    }


}
