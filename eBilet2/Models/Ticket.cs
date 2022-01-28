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
    public class Ticket
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required()]
        public int Number { get; set; }
        [Required()]
        [ForeignKey("EventForeignKey")]
        public Event Event { get; set; }
        [ForeignKey("CustomerForeignKey")]
        public Customer Customer { get; set; }
    }
}
