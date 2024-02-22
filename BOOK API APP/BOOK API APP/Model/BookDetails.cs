using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace BOOK_API_APP.Model
{
    public class BookDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
        public string Descr{ get; set; }
        public int Book_Price { get; set; }
        public int Book_Stock { get; set; }

    }
}
