using Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class TextViewModel
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Text { get; set; }
        public List<Word> ListWords { get; set; }
    }
}
