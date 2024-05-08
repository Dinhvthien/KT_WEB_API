using System.ComponentModel.DataAnnotations;

namespace KT_WEB_API.Entities
{
    public class ProductDetailPropertyDetails
    {
        //ProductDetailPropertyDetailId, ProductDetailId, PropertyDetailId, ProductId
        [Key]
        public int ProductDetailPropertyDetailId { get; set; }
        public int ProductDetailId { get; set; }
        public int PropertyDetailId { get; set; }
        public int ProductId { get; set; }
        public virtual ProductDetails? ProductDetail { get; set; }
        public virtual PropertyDetails? PropertyDetail { get; set; }
        public virtual Products? Product { get; set; }
    }
}
