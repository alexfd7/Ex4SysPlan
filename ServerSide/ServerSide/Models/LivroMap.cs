using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSide.Models
{
    public class LivroMap : ClassMap<Livro>
    {

        public LivroMap()
        {
            Id(c => c.id);
            Map(c => c.Nome).Not.Nullable();            
            References(c => c.autor);
            Map(c => c.estoque).Default("0");
            Table("Livros");
        }

    }
}
