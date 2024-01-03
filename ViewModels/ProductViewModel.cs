using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuminariasWeb.sln.ViewModels
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }

        public decimal Price { get; set; }
        public string Descripcion { get; set; }
    }
}
