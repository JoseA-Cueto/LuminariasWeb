using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace LuminariasWeb.sln.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Password { get; set; }
    }

}
