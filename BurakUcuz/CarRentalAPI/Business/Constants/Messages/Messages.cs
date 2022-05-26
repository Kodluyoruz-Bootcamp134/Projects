using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages
{
    public static class Messages
    {
        public static readonly string CarAdded = "Araba başarıyla eklendi";
        public static readonly string CarDeleted = "Araba başarıyla silindi";
        public static readonly string CarUpdated = "Araba başarıyla güncellendi";
        public static readonly string CarNameInvalid = "Araba ismi geçersiz";
        public static readonly string CarsListed = "Araçlar başarıyla listelendi";

        public static readonly string BrandAdded = "Marka başarıyla eklendi";
        public static readonly string BrandDeleted = "Marka başarıyla silindi";
        public static readonly string BrandUpdated = "Marka başarıyla güncellendi";
        public static readonly string BrandsListed = "Markalar başarıyla listelendi";


        public static readonly string ColorAdded = "Renk çeşidi başarıyla eklendi";
        public static readonly string ColorDeleted = "Renk başarıyla silindi";
        public static readonly string ColorUpdated = "Renk başarıyla güncellendi";
        public static readonly string ColorsListed = "Renkler başarıyla listelendi";


        public static readonly string UserRegistered = "Kullanıcı Kaydı başarıyla oluşturuldu";
        public static readonly string SuccessfulLogin = "Giriş başarılı";
        public static readonly string UserAdded = "Kullanıcı başarıyla eklendi";
        public static readonly string UserDeleted = "Kullanıcı başarıyla silindi";
        public static readonly string UserListed = "Kullanıcı başarıyla listelendi";
        public static readonly string UserUpdated = "Kullanıcı başarıyla güncellendi";
        public static readonly string UserNotFound = "Kullanıcı bulunamadı";
        public static readonly string PasswordError = "Girilen şifre belirlenen adresle uyuşmuyor";
        public static readonly string UserAlreadyExists = "Kullanıcı zaten kayıtlı";
        public static readonly string AccessTokenCreated = "Access Token oluşturuldu";


        public static readonly string CustomerAdded = "Müşteri başarıyla eklendi";
        public static readonly string CustomerDeleted = "Müşteri başarıyla silindi";
        public static readonly string CustomerUpdated = "Müşteri başarıyla güncellendi";
        public static readonly string CustomersListed = "Müşteriler başarıyla listelendi";


        public static readonly string RentalAdded = "Kiralama işlemi eklendi";
        public static readonly string RentalDeleted = "Kiralama işlemi silindi";
        public static readonly string RentalUpdated = "Kiralama işlemi güncellendi";
        public static readonly string RentalsListed = "Kiralama işlemleri listelendi";
        public static readonly string RentalCanNotAdded = "Seçtiğiniz tarihlerde araba kiralanamıyor";


        public static readonly string CarImageUploaded = "Resim dosyası başarıyla eklendi";
        public static readonly string CarImageCanNotUploaded = "Resim dosyası eklenemedi";
        public static readonly string CarImageDeleted = "Resim dosyası başarıyla silindi";
        public static readonly string CarImageUpdated = "Resim dosyası başarıyla güncellendi";
        public static readonly string CarImageLimitExceeded = "Bir araç için en fazla 5 görsel eklenebilir";

        public static readonly string MaintenanceTime = "Sistem bakımda";

        public static readonly string AuthorizationDenied = "Yetkiniz bulunmamakta. Lütfen bilgilerinizi kontrol edin.";
    }
}
