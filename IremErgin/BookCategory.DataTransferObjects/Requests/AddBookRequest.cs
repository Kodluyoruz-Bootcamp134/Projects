using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCategory.DataTransferObjects.Requests
{
    public class AddBookRequest
    {
        [Required(ErrorMessage = "Kitap Adı Gereklidir!")]
        [StringLength(50, ErrorMessage = "Kitap Adı 50 karakterden uzun olamaz!")]
        [MinLength(3, ErrorMessage = "Kitap Adı en az 3 karakterden oluşmalıdır!")]
        public string BookName { get; set; }
        public int Page { get; set; }
        public int? CategoryId { get; set; }
    }
}
