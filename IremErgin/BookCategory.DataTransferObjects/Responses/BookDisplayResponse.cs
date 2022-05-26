using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCategory.DataTransferObjects.Responses
{
    public class BookDisplayResponse
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int Page { get; set; }
        public int? CategoryId { get; set; }
    }
}
