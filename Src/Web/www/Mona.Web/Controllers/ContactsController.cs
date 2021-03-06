﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Mona.Web.Core.Providers;
using Mona.Web.Core.ViewModels.Contacts;


namespace Mona.Web.Controllers
{
    public class ContactsController : Controller
    {
        protected IContactProvider ContactProvider;

        public ContactsController(IContactProvider contactProvider)
        {
            ContactProvider = contactProvider;
        }

        // GET: Contacts
        public async Task<ActionResult> Index()
        {
            List<ContactModel> model = await ContactProvider.GetContacts();
            return View(model);
        }

        // GET: Contacts/Details/5
        public async Task<ActionResult> Details(long id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ContactDeleteOrDetailsModel model = await ContactProvider.GetContactDetails(id);

            if (model == null)
            {
                return HttpNotFound();
            }


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
        public async Task<ActionResult> Create(ContactAddOrUpdateModel model, HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (file.ContentLength > (512*1000))
                {
                    ModelState.AddModelError("FileErrorMessage", "File size must within 512 KB !");
                }

                string[] allowedSettings = {"image/png", "image/gif", "image/jpg", "image/jpeg"};
                bool isFileSettingsValid = false;
                foreach (string allowedSetting in allowedSettings)
                {
                    if (file.ContentType == allowedSetting)
                    {
                        isFileSettingsValid = true;
                        break;
                    }
                }
                if (!isFileSettingsValid)
                {
                    ModelState.AddModelError("FileErrorMessage", "Only .png .gif .jpg and .jpeg file is allowed !");
                }
            }
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string savePath = Server.MapPath("~/Assets/imgs/persons");
                    string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    file.SaveAs(Path.Combine(savePath, fileName));
                    model.Picture = fileName;
                }

                await ContactProvider.CreateContact(model, file);
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
            ContactAddOrUpdateModel model = await ContactProvider.GetContact(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(long id, ContactAddOrUpdateModel model, HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (file.ContentLength > (512*1000))
                {
                    ModelState.AddModelError("FileErrorMessage", "File size must within 512 KB !");
                }

                string[] allowedSettings = {"image/png", "image/gif", "image/jpg", "image/jpeg"};
                bool isFileSettingsValid = false;
                foreach (string allowedSetting in allowedSettings)
                {
                    if (file.ContentType == allowedSetting)
                    {
                        isFileSettingsValid = true;
                        break;
                    }
                }
                if (!isFileSettingsValid)
                {
                    ModelState.AddModelError("FileErrorMessage", "Only .png .gif .jpg and .jpeg file is allowed !");
                }
            }
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string savePath = Server.MapPath("~/Assets/imgs/persons");
                    string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    file.SaveAs(Path.Combine(savePath, fileName));
                    model.Picture = fileName;
                }

                await ContactProvider.UpdateContact(id, model, file);
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
            ContactDeleteOrDetailsModel model = await ContactProvider.GetContactDetails(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id, ContactDeleteOrDetailsModel model)
        {
            ContactDeleteOrDetailsModel contact = await ContactProvider.GetContactDetails(id);
            if (model != null)
            {
                await ContactProvider.DeleteContact(id, contact);
            }

            return RedirectToAction("Index");
        }
    }
}