using ACLC_WebDevMidtermExam_Group01.DataConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using ACLC_WebDevMidtermExam_Group01.Models;

namespace ACLC_WebDevMidtermExam_Group01.Controllers
{
    public class UserController : Controller
    {
        private readonly MySqlDbContext _context;
        public UserController(MySqlDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(string id)
        {
            var User = from p in _context.user
                       select p;
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    int pId = Convert.ToInt32(id);
                    User = User.Where(p => p.id == pId);
                }
                catch (FormatException ee)
                {

                }

            }
            return View(await User.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind()] Models.User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.user.Add(user);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View();
            }
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            if (id == null || _context.user == null)
            {
                return NotFound();
            }
            var p = _context.user.Find(id);

            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind()] Models.User user)
        {
            if (id != user.id)
            {
                return NotFound();

            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View(user);
        }
        public ActionResult Delete(int id)
        {
            Models.User p = _context.user.Find(id);

            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [Bind()] Models.User user)
        {


            Models.User p = _context.user.Find(id);


            try
            {
                _context.Remove(p);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

            return View(p);
        }

    }
}
