using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSide.Models
{
    public class AutorMap : ClassMap<Autor>
    {
        public AutorMap()
        {
            Id(c => c.id);
            Map(c => c.Nome).Not.Nullable();
            Table("Autores");
        }
    }
}
