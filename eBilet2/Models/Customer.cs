using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBilet2.Models
{
    public class Customer
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Proszę podać imię!")]
        [MinLength(2, ErrorMessage = "Minimalna długość wynosi 2 znaki")]
        [MaxLength(30, ErrorMessage = "Maksymalna długość 30 znaków")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwisko!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Proszę podać poprawny eamil!")]
        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; }

        public CustomerStatus Status { get; set; }

        //public ICollection<Ticket> Tickets { get; set; }
    }

    public enum CustomerStatus
    {
        [Display(Name = "Aktywny")]
        Active = 1,
        [Display(Name = "Zablokowany")]
        Blocked,
        [Display(Name = "Usunięty")]
        Removed,
    }
}