using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Services.Utilites
{
    public static class Messages
    {
        // Messages.Category.NotFound()
        public static class Category
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir kategori bulunamadı.";
                return "Böyle bir kategori bulunamadı.";
            }

            public static string Add(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla eklenmiştir.";
            }

            public static string Update(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla güncellenmiştir.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla silinmiştir.";
            }
            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla veritabanından silinmiştir.";
            }
        }

        public static class Report
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Haberler bulunamadı.";
                return "Böyle bir haber bulunamadı.";
            }
            public static string Add(string reportTitle)
            {
                return $"{reportTitle} başlıklı haber başarıyla eklenmiştir.";
            }

            public static string Update(string reportTitle)
            {
                return $"{reportTitle} başlıklı haber başarıyla güncellenmiştir.";
            }
            public static string Delete(string reportTitle)
            {
                return $"{reportTitle} başlıklı haber başarıyla silinmiştir.";
            }
            public static string HardDelete(string reportTitle)
            {
                return $"{reportTitle} başlıklı haber başarıyla veritabanından silinmiştir.";
            }
        }
    }
}