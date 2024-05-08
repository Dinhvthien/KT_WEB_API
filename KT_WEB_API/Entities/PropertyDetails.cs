using System.ComponentModel.DataAnnotations;

namespace KT_WEB_API.Entities
{
    public class PropertyDetails
    {
        //PropertyDetailId, PropertyId,  PropertyDetailCode, PropertyDetailDetail
        [Key]
        public int PropertyDetailId { get; set; }
        public int PropertyId { get; set; }
        public string PropertyDetailCode { get; set; }
        public string PropertyDetailDetail { get; set; }
        public virtual List<ProductDetailPropertyDetails>? ProductDetailPropertyDetails { get; set; }
        public virtual Properties? Properties { get; set; }
    }
}
