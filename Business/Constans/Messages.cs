using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
    public static class Messages
    {
        //Category
        public static string CategoryAdded = "Kategori eklendi";
        public static string CategoryDeleted = "Kategori silindi";
        public static string CategoryUpdated = "Kategori güncellendi";
        public static string CategoryListed = "Kategoriler listelendi";
        //House
        public static string HouseAdded = "Ev eklendi";
        public static string HouseDeleted = "Ev silindi";
        public static string HouseUpdated = "Ev güncellendi";
        public static string HouseListed = "Evler listelendi";
        //House Rental
        public static string HouseRentalAdded = "Kiralama işlemi başarılı";
        public static string HouseRentalDeleted = "Kiralama iptal edildi";
        public static string HouseRentalListed = "Tüm kiralama işlemleriniz listelendi";
        public static string HouseRentalUpdated = "Kiralama bilgisi güncellendi";
        //User
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserListed = "Kullanıcılar listelendi";
        public static string UserUpdated = "Kullanıcılar güncellendi";

        //Auth
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string UserRegistered = "Kayıt oldu";
        public static string AuthorizationDenied = "Yetkiniz yok";

        //House Image
        public static string HouseImageLimitExceeded = "Bir konut için maksimum  5 resim eklenebilir";
        public static string HouseImageDeleted = "Konut resmi silindi";
        public static string HouseImageUpdated = "konut resmi güncellendi";
    }
}
