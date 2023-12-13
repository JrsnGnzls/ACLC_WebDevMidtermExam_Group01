using ACLC_WebDevMidtermExam_Group01.DataConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using ACLC_WebDevMidtermExam_Group01.Models;

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

        public ActionResult View(int id)
        {
            Models.joborder p = _context.form.Find(id);

            return View(p);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind()] Models.joborder joborder)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.form.Add(joborder);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View();
            }
            return View(joborder);
        }

        public ActionResult Edit(int id)
        {
            if (id == null || _context.form == null)
            {
                return NotFound();
            }
            var p = _context.form.Find(id);

            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind()] Models.joborder joborder)
        {
            if (id != joborder.id)
            {
                return NotFound();

            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(joborder);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View(joborder);
        }
        public ActionResult Delete(int id)
        {
            Models.joborder p = _context.form.Find(id);

            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [Bind()] Models.joborder joborder)
        {


            Models.joborder p = _context.form.Find(id);


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
