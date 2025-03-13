
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kitap başlığı gereklidir.")]
        [Display(Name = "Kitap Başlığı")]
        public string Title { get; set; }

        [Display(Name = "Yazar")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Kitap türü gereklidir.")]
        [Display(Name = "Tür")]
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Yayın Tarihi")]
        public DateTime PublishDate { get; set; }

        [Required(ErrorMessage = "ISBN numarası gereklidir.")]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Kopya sayısı gereklidir.")]
        [Display(Name = "Mevcut Kopya Sayısı")]
        [Range(0, int.MaxValue, ErrorMessage = "Kopya sayısı 0 veya daha büyük olmalıdır.")]
        public int CopiesAvailable { get; set; }

        // Navigation property
        public Author Author { get; set; }
    }
}