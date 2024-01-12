using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookingProject.Dal.Entities
{
	public class Contacts
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string ContactsID { get; set; }
		public string Description { get; set; }
		public string Adress {  get; set; }
		public string No {  get; set; }
		public string Mail { get; set; }
		public string Fax { get; set; }

	}
}
