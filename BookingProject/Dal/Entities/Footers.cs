using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookingProject.Dal.Entities
{
	public class Footers
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string FootersID { get; set; }
		public string Description { get; set; }
		public string Facebook {  get; set; }
		public string Twitter { get; set; }
		public string Instagram { get; set; }
		public string Youtube { get; set; }
		public string No {  get; set; }
		public string Mail { get; set; }
		public string Adress { get; set; }
		public string City { get; set; }
		public string Designer { get; set; }

	}
}
