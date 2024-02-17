using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuminariasWeb.sln.Models
{

    public class ImageFile
    {
     
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ContentType { get; set; }      
        [Required]
        public string Path { get; set; }     
        [Required]
        public string PhysicalPath { get; set; }   
        public int Size { get; set; } 
        public DateTime CreateDate { get; set; }      
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
