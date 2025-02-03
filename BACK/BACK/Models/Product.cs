using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BACK.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId DatabaseId { get; set; }

        [BsonIgnore]
        public string Id { get => DatabaseId.ToString(); set => DatabaseId = ObjectId.Parse(value); }
        public string Name { get; set; }
        [Required(ErrorMessage = "The name that product is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "The base rate is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The base rate must be a positive value.")]

        public double Price { get; set; }
        [Required(ErrorMessage = "The stock that product is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The stock min value 1.")]
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreationAt { get; set; }

        public Product()
        {
            CreationAt = DateTime.Now;
        }



    }
}
