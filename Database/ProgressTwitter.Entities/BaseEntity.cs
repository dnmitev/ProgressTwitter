using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTwitter.Entities
{
    /// <summary>
    /// Abstract Entity for all the BusinessEntities.
    /// </summary>
    [Serializable]
    [BsonIgnoreExtraElements(Inherited = true)]
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
        }

        /// <summary>
        /// Gets or sets the id for this object (the primary record for an entity).
        /// </summary>
        /// <value>The id for this object (the primary record for an entity).</value>
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; set; }
    }
}
