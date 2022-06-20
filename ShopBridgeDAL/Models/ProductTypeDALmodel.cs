using System.ComponentModel.DataAnnotations;

namespace ShopBridgeDAL.Models
{
    public class ProductTypeDALmodel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Type")]
        public string? ProductType { get; set; }


    }
}