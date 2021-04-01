using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SürücuKursu.Entities
{
    [Table("Notes")]
    public class Note : EntityBase
    {
        [Required, StringLength(60)]
        public string Title { get; set; }
        [Required, StringLength(2000)]
        public string Text { get; set; }
        //public virtual SürücüKursuUser Owner { get; set; }
        public virtual List<Comment> Comments { get; set; }

        public Note()
        {
            Comments = new List<Comment>();
        }
    }
}
