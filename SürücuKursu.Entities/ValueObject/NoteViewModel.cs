using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SürücuKursu.Entities.ValueObject
{
    public class NoteViewModel
    {
        [DisplayName("İçerik"),]
        public string text { get; set; }

        [DisplayName("Başlık")]
        public string tittle { get; set; }
        [Key]
        public int Id { get; set; }

    }
}
