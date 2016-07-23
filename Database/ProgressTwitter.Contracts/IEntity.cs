namespace ProgressTwitter.Contracts
{
    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    /// General interface for a DB entity
    /// </summary>
    /// <typeparam name="T">The type of the Id</typeparam>
    public interface IEntity<T>
    {
        [BsonId]
        T Id { get; set; }
    }
}
