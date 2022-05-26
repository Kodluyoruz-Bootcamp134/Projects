using MovieStore.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Entities
{
    public class Movie : BaseEntity
    {
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }


        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }



    }
}
