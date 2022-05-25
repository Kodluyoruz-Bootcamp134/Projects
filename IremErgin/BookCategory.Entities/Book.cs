using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCategory.Entities
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int Page { get; set; }
        public int? CategoryId { get; set; }
        public bool IsActive { get; set; } = true;

        public Category Category { get; set; }


        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        
    }
}
