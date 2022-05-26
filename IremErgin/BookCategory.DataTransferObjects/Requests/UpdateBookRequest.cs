using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCategory.DataTransferObjects.Requests
{
    public class UpdateBookRequest
    {
        public int Id { get; set; }
        [Required]
        public string BookName { get; set; }
        public int Page { get; set; }
        public int? CategoryId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
