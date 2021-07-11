using Epam.BoardGamesForum.Entities;
using Epam.BoardGamesForum.SqlDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.BoardGamesForum.BLL
{
    public class ForumPostsLogic
    {
        ForumPostsSqlDAL ForumPostsSqlDAL = new ForumPostsSqlDAL();
        public void AddPost(string text, User author, Theme theme)
        {
            Guid id = HashGenerator.GenerateHash();
            DateTime publicationDate = DateTime.Now;
            Guid authorId = author.id;
            Guid themeId = theme.id;

            ForumPost post = new ForumPost(id, text, publicationDate, authorId, themeId);
            ForumPostsSqlDAL.AddPost(post);
        }

        public void DeletePost(Guid id)
        {
            ForumPostsSqlDAL.DeletePost(id);
        }

        // TODO
        /*
        public ForumPost GetPost(Guid id)
        {
            ForumPost post = ForumPostsSqlDAL.GetPost();
            return post;
        }*/

        public IEnumerable<ForumPost> GetPosts()
        {
            return ForumPostsSqlDAL.GetPosts();
        }
    }
}
