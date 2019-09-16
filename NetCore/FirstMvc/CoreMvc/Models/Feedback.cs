using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace CoreMvc.Models
{
    public class Feedback
    {
        [BindNever]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Your name is required")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Your email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Your Message is required")]
        public string Message { get; set; }

        public bool ContactMe { get; set; }
    }
}
