using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSide.Models
{
    public class Livro
    {
        public virtual int id { get; set; }        
        public virtual Autor autor { get; set; }
        public virtual string Nome { get; set; }

        public virtual int estoque { get; set; }
    }
}
