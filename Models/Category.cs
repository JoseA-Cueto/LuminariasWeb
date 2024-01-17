using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LuminariasWeb.sln.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        // Relación con la entidad Product
        public List<Product> Products { get; set; }
    }
}
