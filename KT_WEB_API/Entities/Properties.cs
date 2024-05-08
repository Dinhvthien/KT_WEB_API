using System.ComponentModel.DataAnnotations;

namespace KT_WEB_API.Entities
{
    public class Properties
    {
        //PropertyId, ProductId, PropertyName, PropertySort
        [Key]
        public int PropertyId { get; set; }
        public int ProductId { get; set; }
        public string PropertyName { get; set; }
        public string PropertySort { get; set; }
        public virtual Products? Product {  get; set; }   
        public virtual List<PropertyDetails>? PropertyDetails {  get; set; }


    }
}
