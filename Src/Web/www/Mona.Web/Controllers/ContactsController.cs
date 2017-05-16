﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Mona.Web.Data;
using Mona.Web.Entities;
using Mona.Web.Helpers;
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
                    var builder = new ContactModel
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
        public async Task<ActionResult> Details(long id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FirstOrDefaultAsync(o => o.Id == id);

            if (contact == null)
            {
                return HttpNotFound();
            }

            var model = new ContactDeleteOrDetailsModel
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
            var model = new ContactAddOrUpdateModel();
            return View(model);
        }

        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContactAddOrUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var contact = new Contact
                {
                  Id   =  new long(), 
                  Code = CodeGeneratorHelper.GenerateCode(),
                  ContactType = model.ContactType,
                  Picture = model.Picture,
                  FirstName = model.FirstName,
                  LastName = model.LastName,
                  PhoneNumber = model.PhoneNumber,
                  Email = model.Email,
                  TwiterAddress = model.TwiterAddress,
                  FaceBookAddress = model.FaceBookAddress

                };
                db.Contacts.Add(contact);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Contacts/Edit/5
        public async Task<ActionResult> Edit(long id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FirstOrDefaultAsync(o => o.Id == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            var model = new ContactAddOrUpdateModel
            {
                Code = contact.Code,
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

        // POST: Contacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(long id, ContactAddOrUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var contact = await db.Contacts.FirstOrDefaultAsync(o => o.Id == id);
                if (model != null)
                {
                    contact.Picture = model.Picture;
                    contact.ContactType = model.ContactType;
                    contact.FirstName = model.FirstName;
                    contact.LastName = model.LastName;
                    contact.PhoneNumber = model.PhoneNumber;
                    contact.Email = model.Email;
                    contact.TwiterAddress = model.TwiterAddress;
                    contact.FaceBookAddress = model.FaceBookAddress;
                }
                db.Entry(contact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Contacts/Delete/5
        public async Task<ActionResult> Delete(long id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FirstOrDefaultAsync(o => o.Id == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            var model = new  ContactDeleteOrDetailsModel
            {
                Code = contact.Code,
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

       
    }
}
