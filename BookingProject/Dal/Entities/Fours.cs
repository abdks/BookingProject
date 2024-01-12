using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace BookingProject.Dal.Entities
{
	public class Fours
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string FoursID { get; set; }
		public string Image { get; set; }
		public string Title { get; set; }
		public decimal Price { get; set; }

	}
}
