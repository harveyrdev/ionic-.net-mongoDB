using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BACK.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public ObjectId DatabaseId { get; set; }
        [BsonIgnore]
        public string Id
        {
            get => DatabaseId.ToString();
            set => DatabaseId = ObjectId.Parse(value);
        }
        [Required]
        public string customerName { get; set; }
        public decimal totalAmount { get; set; }
        public DateTime orderDate { get; set; }
        [Required(ErrorMessage = "At least one guest is required.")]
        [MinLength(1, ErrorMessage = "At least one guest is required.")]
        public List<Product> orderItems { get; set; }

        public Order()
        {
            orderDate = DateTime.Now;
        }
    }
}
