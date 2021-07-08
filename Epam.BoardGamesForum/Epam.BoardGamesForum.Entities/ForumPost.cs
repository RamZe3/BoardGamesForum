using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.BoardGamesForum.Entities
{
    public class ForumPost
    {
        public string id { get; set; }
        public string text { get; set; }
        public DateTime publicationDate { get; set; }
        public string authorId { get; set; }
        public string themeId { get; set; }

        public ForumPost(string id, string text, DateTime publicationDate, string authorId, string themeId)
        {
            this.id = id;
            this.text = text;
            this.publicationDate = publicationDate;
            this.authorId = authorId;
            this.themeId = themeId;
        }
    }
}
