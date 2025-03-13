
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Yazarın adı gereklidir.")]
        [Display(Name = "Adı")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Yazarın soyadı gereklidir.")]
        [Display(Name = "Soyadı")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Doğum Tarihi")]
        public DateTime DateOfBirth { get; set; }

        // Navigation property
        public ICollection<Book> Books { get; set; }

        [Display(Name = "Tam Ad")]
        public string FullName => $"{FirstName} {LastName}";
    }
}