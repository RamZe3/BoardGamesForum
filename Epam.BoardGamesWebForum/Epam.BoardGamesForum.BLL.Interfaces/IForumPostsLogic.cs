using Epam.BoardGamesForum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.BoardGamesForum.BLL.Interfaces
{
    public interface IForumPostsLogic
    {
        void AddPost(string text, User author, Theme theme);
        void DeletePost(Guid id);
        void DeletePost(string id);
        ForumPost GetPost(Guid id);
        IEnumerable<ForumPost> GetPosts();
        void EditPost(Guid id, string newText);
    }
}
