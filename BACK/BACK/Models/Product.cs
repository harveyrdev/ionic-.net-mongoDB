using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BACK.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId databaseId { get; set; }

        [BsonIgnore]
        public string id { get => databaseId.ToString(); set => databaseId = ObjectId.Parse(value); }
        public string name { get; set; }
        [Required(ErrorMessage = "The name that product is required.")]
        public string description { get; set; }
        [Required(ErrorMessage = "The base rate is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The base rate must be a positive value.")]

        public double price { get; set; }
        [Required(ErrorMessage = "The stock that product is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The stock min value 1.")]
        public int stock { get; set; }
        public string imageUrl { get; set; }
        //public DateTime CreationAt { get; set; }

        //public Product()
        //{
        //    CreationAt = DateTime.Now;
        //}



    }
}
