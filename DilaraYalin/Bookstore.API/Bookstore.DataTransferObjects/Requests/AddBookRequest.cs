using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.DataTransferObjects.Requests
{
    public class AddBookRequest
    {
        [Required(ErrorMessage = "Kitap adı gereklidir.")]
        [StringLength(50, ErrorMessage = "Kitap adı 30 karatkerden uzun olamaz.")]
        [MinLength(2, ErrorMessage ="Kitap adı en az 2 karakterden oluşmalıdır.")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public double? Price { get; set; }
        public int? Stock { get; set; }
        public int? GenreId { get; set; }
    }
}
