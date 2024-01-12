using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookingProject.Dal.Entities
{
	public class Blogs
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string BlogsID { get; set; }
		public string BlogsName { get; set; }
		public string Date {  get; set; }
		public string Description { get; set; }
	}
}
