using Epam.BoardGamesForum.Entities;
using Epam.BoardGamesForum.SqlDAL;
using System;
using System.Collections.Generic;
using System.Text;
using Epam.BoardGamesForum.BLL.Interfaces;
using Epam.BoardGamesForum.DAL.Interfaces;

namespace Epam.BoardGamesForum.BLL
{
    public class ForumPostsLogic : IForumPostsLogic
    {
        private IForumPostsDAL _ForumPostsDAL;

        public ForumPostsLogic(IForumPostsDAL forumPostsDAL)
        {
            _ForumPostsDAL = forumPostsDAL;
        }

        public void AddPost(string text, User author, Theme theme)
        {
            Guid id = HashGenerator.GenerateHash();
            DateTime publicationDate = DateTime.Now;
            Guid authorId = author.id;
            Guid themeId = theme.id;

            ForumPost post = new ForumPost(id, text, publicationDate, authorId, themeId);
            _ForumPostsDAL.AddPost(post);
        }

        public void DeletePost(Guid id)
        {
            _ForumPostsDAL.DeletePost(id);
        }
        public void DeletePost(string id)
        {
            Guid guidId = new Guid(id);
            _ForumPostsDAL.DeletePost(guidId);
        }


        public ForumPost GetPost(Guid id)
        {
            ForumPost post = _ForumPostsDAL.GetPost(id);
            return post;
        }

        public IEnumerable<ForumPost> GetPosts()
        {
            return _ForumPostsDAL.GetPosts();
        }

        public void EditPost(Guid id, string newText)
        {
            _ForumPostsDAL.EditPost(id, newText);
        }
    }
}
