using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookingProject.Dal.Entities
{
	public class Testimonials
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string TestimonalsID { get; set; }
		public string Description { get; set; }
		public string NameSurname { get; set; }

	}
}
