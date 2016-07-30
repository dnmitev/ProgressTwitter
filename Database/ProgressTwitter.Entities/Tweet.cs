using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTwitter.Entities
{
    public class Tweet : BaseEntity
    {
        public string Tweetid { get; set; }

        public string Text { get; set; }

        public string UseByrId { get; set; }

        public string UserByScreenName { get; set; }
    }
}
