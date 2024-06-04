using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace basit_e_ticaret_uygulaması_crud.Models
{
    public class ProductDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";
        [Required, MaxLength(100)]
        public string Brand { get; set; } = "";
        [Required, MaxLength(100)]
        public string Category { get; set; } = "";
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; } = "";
        [MaxLength(100)]
        public IFormFile? ImageFile { get; set; }
    }
}
