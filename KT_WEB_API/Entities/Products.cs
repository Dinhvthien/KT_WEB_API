using System.ComponentModel.DataAnnotations;

namespace KT_WEB_API.Entities
{
    public class Products
    {
        //ProductId, ProductName
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public virtual List<ProductDetailPropertyDetails>? ProductDetailPropertyDetails { get; set; }
        public virtual List<Properties>? Properties { get; set; }

    }
}
