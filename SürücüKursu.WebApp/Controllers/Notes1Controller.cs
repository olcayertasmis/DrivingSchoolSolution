using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SürücüKursu.BusinessLayer;
using SürücuKursu.Entities;
using SürücuKursu.Entities.ValueObject;

namespace SürücüKursu.WebApp.Controllers
{
    public class Notes1Controller : Controller
    {
        //Repository<Note> repo_note = new Repository<Note>();
        NoteManager noteManager = new NoteManager();
        public ActionResult Index(int? id)
        {

            return View(noteManager.GetAllNotes());
        }

        public ActionResult Details(Note model)
        {
            Repository<Note> repo_note = new Repository<Note>();
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = repo_note.Find(x => x.Id == model.Id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text,CreatedOn")] Note note)
        {
            if (ModelState.IsValid)
            {
                Repository<Note> repo_note = new Repository<Note>();
                repo_note.Insert(note);
                repo_note.Save();
                return RedirectToAction("Index");
            }

            return View(note);
        }
        public ActionResult Edit(NoteViewModel model)
        {
            Repository<Note> repo_note = new Repository<Note>();
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note a = repo_note.Find(x => x.Id == model.Id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,CreatedOn")] Note note)
        {
            if (ModelState.IsValid)
            {
                Repository<Note> repo_note = new Repository<Note>();
                Note note2 = repo_note.Find(x => x.Id == note.Id);
                if (note2 != null)
                {
                    note2.Text = note.Text;
                    note2.Title = note.Title;
                    note2.CreatedOn = note.CreatedOn;
                }
                //repo_note.Update(note);
                //repo_note.Delete(note);
                //repo_note.Update(new Note
                //{
                //    Text = note.Text,
                //    Title = note.Title,
                //    Id = note.Id,
                //    Comments = note.Comments,
                //    CreatedOn = note.CreatedOn
                //});
                //repo_note.Save();
                return RedirectToAction("Index");
            }
            return View(note);
        }

        public ActionResult Delete(Note model)
        {
            Repository<Note> repo_note = new Repository<Note>();
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note a = repo_note.Find(x => x.Id == model.Id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Note note)
        {
            Repository<Note> repo_note = new Repository<Note>();
            Note note2 = repo_note.Find(x => x.Id == note.Id);
            repo_note.Delete(note2);
            repo_note.Save();
            return RedirectToAction("Index");
        }
        //public ActionResult GetNoteText(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    //Repository<Note> repo_note = new Repository<Note>();
        //    //Note note = noteManager.Find(int a);
        //    return View();
        //}
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
