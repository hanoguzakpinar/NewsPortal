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
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla geri getirilmiştir.";
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

            public static string UndoDelete(string reportTitle)
            {
                return $"{reportTitle} adlı haber başarıyla geri getirilmiştir.";
            }
        }

        public static class Comment
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir yorum bulunamadı.";
                return "Böyle bir yorum bulunamadı.";
            }
            public static string Approve(int commentId)
            {
                return $"{commentId} no'lu yorumun başarıyla onaylanmıştır.";
            }

            public static string Add(string createdByName)
            {
                return $"Sayın {createdByName}, yorumunuz başarıyla eklenmiştir.";
            }

            public static string Update(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla güncellenmiştir.";
            }
            public static string Delete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla silinmiştir.";
            }
            public static string HardDelete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla geri getirilmiştir.";
            }
        }
    }
}