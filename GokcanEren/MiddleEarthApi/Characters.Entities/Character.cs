using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters.Entities
{
    public class Character:IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int RaceId { get; set; }

        public string ImageUrl { get; set; }

        public Race Race { get; set; }

        public bool isAlive { get; set; } = true;


    }
}
