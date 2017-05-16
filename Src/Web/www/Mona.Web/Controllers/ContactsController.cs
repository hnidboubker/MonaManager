using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Twitter;
using Mona.Web.Data;
using Mona.Web.Entities;
using Mona.Web.ViewModels.Contacts;

namespace Mona.Web.Controllers
{
    public class ContactsController : Controller
    {
        private DefaultContext db = new DefaultContext();

        // GET: Contacts
        public async Task<ActionResult> Index()
        {
            var model = new List<ContactModel>();
            var query = await db.Contacts.OrderBy(o => o.FirstName).ToListAsync();
            if (query.Any())
            {
                foreach (var c in query)
                {
                    var builder = new ContactModel()
                    {
                        Id =  c.Id,
                        Picture = c.Picture,
                        FullName = c.FullName,
                        PhoneNumber = c.PhoneNumber,
                        Email = c.Email
                    };
                    model.Add(builder);
                }
            }
            return View(model);
        }

        // GET: Contacts/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FirstOrDefaultAsync(o => o.Id == id);

            if (contact == null)
            {
                return HttpNotFound();
            }

            var model = new ContactDeleteOrDetailsModel()
            {
                Code =  contact.Code,
               Picture = contact.Picture,
               ContactType = contact.ContactType,
               FirstName = contact.FirstName,
               LastName = contact.LastName,
               PhoneNumber = contact.PhoneNumber,
               Email = contact.Email,
               TwiterAddress = contact.TwiterAddress,
               FaceBookAddress = contact.FaceBookAddress
            };
            return View(model);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Picture,ContactType,FirstName,LastName,PhoneNumber,Email,TwiterAddress,FaceBookAddress")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FirstOrDefaultAsync(o => o.Id == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Picture,ContactType,FirstName,LastName,PhoneNumber,Email,TwiterAddress,FaceBookAddress")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FirstOrDefaultAsync(o => o.Id == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Contact contact = await db.Contacts.FirstOrDefaultAsync(o => o.Id == id);
            db.Contacts.Remove(contact);
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
