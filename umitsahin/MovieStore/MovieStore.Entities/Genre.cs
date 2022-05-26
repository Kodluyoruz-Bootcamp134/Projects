using MovieStore.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Entities
{
    public class Genre:BaseEntity
    {
        public string GenreName { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
