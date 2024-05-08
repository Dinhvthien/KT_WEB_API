using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace KT_WEB_API.Entities
{
    public class ProductDetails
    {
        //ProductDetailId, ProductDetailName, Quantity, Price, ShellPrice, ParentId
        [Key]
        public int ProductDetailId { get; set; }
        public string ProductDetailName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        [Column(TypeName = "float")]
        public double Price { get; set; }
        [Column(TypeName = "float")]
        public double ShellPrice { get; set; }
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public  ProductDetails? Parent { get; set; }
        public virtual ICollection<ProductDetailPropertyDetails>? ProductDetailPropertyDetails { get; set; }
    }
}
