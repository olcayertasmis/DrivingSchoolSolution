using SürücüKursu.BusinessLayer;
using SürücuKursu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SürücüKursu.WebApp.Controllers
{
    public class CommentsController : Controller
    {
        private NoteManager nm = new NoteManager();
        public ActionResult ShowNoteComments(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //Note note = nm.Getnote().
            //if (note == null)
            //{
            //    return HttpNotFound();
            //}
            return PartialView("_PartialComments");
        }
    }
}