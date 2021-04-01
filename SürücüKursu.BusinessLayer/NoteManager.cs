using SürücuKursu.Entities;
using SürücuKursu.Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SürücüKursu.BusinessLayer
{
    public class NoteManager
    {
        Repository<Note> repo_note = new Repository<Note>();
        public Note Find(int id)
        {
            return repo_note.Find(x => x.Id == id);
        }

        //public Note Getnote(int id)
        //{
        //    return repo_note.Find(x => x.Id == id);
        //}
        public List<Note> GetAllNotes()
        {
            return repo_note.List();
        }
        public void CreateNote(NoteViewModel data)
        {
            repo_note.Insert(new Note()
            {
                Title = data.tittle,
                Text = data.text,
            });
        }

        //public void UpdateNote(NoteViewModel data)
        //{
        //    Note note2 = repo_note.Note.Where(x => x.Id == urunid).FirstOrDefault();
        //}

    }
}
