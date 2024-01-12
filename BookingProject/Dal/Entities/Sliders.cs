using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace BookingProject.Dal.Entities
{
	public class Sliders
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string SlidersID { get; set; }
		public string ImageURL { get; set; }
	}
}
