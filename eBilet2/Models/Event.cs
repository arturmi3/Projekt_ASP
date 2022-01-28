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
    public class Event
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Proszę nazwę imprezy!")]
        [MinLength(10, ErrorMessage = "Minimalna długość wynosi 10 znaków")]
        [MaxLength(100, ErrorMessage = "Maksymalna długość 100 znaków")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwisko!")]
        [DataType(DataType.MultilineText)]
        public string Localization { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        [Required(ErrorMessage = "Wybierz typ imprezy")]
        public EventType EventType { get; set; }
        [Required(ErrorMessage = "Podaj liczbę biletów")]
        public int TicketLimit { get; set; }

        //public virtual ICollection<Ticket> Tickets { get; set; }
    }

    public enum EventType
    {
        Concert,
        Sport,
        Movie,
    }
}
