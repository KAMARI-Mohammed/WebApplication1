using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SubjectProfessorsController : Controller
    {
        private WebApplication1Context db = new WebApplication1Context();

        // GET: SubjectProfessors
        public async Task<ActionResult> Index()
        {
            return View(await db.SubjectProfessors.ToListAsync());
        }

        // GET: SubjectProfessors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectProfessor subjectProfessor = await db.SubjectProfessors.FindAsync(id);
            if (subjectProfessor == null)
            {
                return HttpNotFound();
            }
            return View(subjectProfessor);
        }

        // GET: SubjectProfessors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubjectProfessors/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id")] SubjectProfessor subjectProfessor)
        {
            if (ModelState.IsValid)
            {
                db.SubjectProfessors.Add(subjectProfessor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(subjectProfessor);
        }

        // GET: SubjectProfessors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectProfessor subjectProfessor = await db.SubjectProfessors.FindAsync(id);
            if (subjectProfessor == null)
            {
                return HttpNotFound();
            }
            return View(subjectProfessor);
        }

        // POST: SubjectProfessors/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] SubjectProfessor subjectProfessor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectProfessor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(subjectProfessor);
        }

        // GET: SubjectProfessors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectProfessor subjectProfessor = await db.SubjectProfessors.FindAsync(id);
            if (subjectProfessor == null)
            {
                return HttpNotFound();
            }
            return View(subjectProfessor);
        }

        // POST: SubjectProfessors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SubjectProfessor subjectProfessor = await db.SubjectProfessors.FindAsync(id);
            db.SubjectProfessors.Remove(subjectProfessor);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
