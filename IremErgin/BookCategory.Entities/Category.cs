﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCategory.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
