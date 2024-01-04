using System.ComponentModel.DataAnnotations;

namespace LuminariasWeb.sln.ViewModels
{
    public class ServiceViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }
    }
}
