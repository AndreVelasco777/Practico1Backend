using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Pregunta1.Models
{
    public enum Places
    {
        Santa_Cruz = 1,
        Pando = 2,
        Beni = 3,
        Tarija = 4,
        Cochabamba = 5
    }
    public class velasco
    {
        [Key]
        public int velascoID { get; set; }
        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(24), MinLength(2)]
        public string Friendofvelasco { get; set; }
        [Required]
        public Places places { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Invalido")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Cumpleaños")]
        public DateTime Birthdate { get; set; }
    }
}