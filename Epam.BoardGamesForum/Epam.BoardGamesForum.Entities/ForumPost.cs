using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.BoardGamesForum.Entities
{
    public class ForumPost
    {
        public Guid id { get; set; }
        public string text { get; set; }
        public DateTime publicationDate { get; set; }
        public Guid authorId { get; set; }
        public Guid themeId { get; set; }

        public ForumPost(Guid id, string text, DateTime publicationDate, Guid authorId, Guid themeId)
        {
            this.id = id;
            this.text = text;
            this.publicationDate = publicationDate;
            this.authorId = authorId;
            this.themeId = themeId;
        }
    }
}
