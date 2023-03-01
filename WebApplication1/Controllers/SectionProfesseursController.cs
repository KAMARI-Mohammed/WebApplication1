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
    public class SectionProfesseursController : Controller
    {
        private WebApplication1Context db = new WebApplication1Context();

        // GET: SectionProfesseurs
        public async Task<ActionResult> Index()
        {
            return View(await db.SectionProfesseurs.ToListAsync());
        }

        // GET: SectionProfesseurs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionProfesseur sectionProfesseur = await db.SectionProfesseurs.FindAsync(id);
            if (sectionProfesseur == null)
            {
                return HttpNotFound();
            }
            return View(sectionProfesseur);
        }

        // GET: SectionProfesseurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SectionProfesseurs/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id")] SectionProfesseur sectionProfesseur)
        {
            if (ModelState.IsValid)
            {
                db.SectionProfesseurs.Add(sectionProfesseur);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sectionProfesseur);
        }

        // GET: SectionProfesseurs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionProfesseur sectionProfesseur = await db.SectionProfesseurs.FindAsync(id);
            if (sectionProfesseur == null)
            {
                return HttpNotFound();
            }
            return View(sectionProfesseur);
        }

        // POST: SectionProfesseurs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] SectionProfesseur sectionProfesseur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sectionProfesseur).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sectionProfesseur);
        }

        // GET: SectionProfesseurs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionProfesseur sectionProfesseur = await db.SectionProfesseurs.FindAsync(id);
            if (sectionProfesseur == null)
            {
                return HttpNotFound();
            }
            return View(sectionProfesseur);
        }

        // POST: SectionProfesseurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SectionProfesseur sectionProfesseur = await db.SectionProfesseurs.FindAsync(id);
            db.SectionProfesseurs.Remove(sectionProfesseur);
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
