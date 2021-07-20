using Epam.BoardGamesForum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.BoardGamesForum.DAL.Interfaces
{
    public interface IForumPostsDAL
    {
        ForumPost AddPost(ForumPost forumPost);
        void DeletePost(Guid id);
        IEnumerable<ForumPost> GetPosts();
        ForumPost GetPost(Guid id);
        void EditPost(Guid id, string newText);

    }
}
