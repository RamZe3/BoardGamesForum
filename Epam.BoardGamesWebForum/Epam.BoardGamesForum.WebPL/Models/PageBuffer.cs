using Epam.BoardGamesForum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.BoardGamesForum.BLL
{
    public static class PageBuffer
    {
        public static User nowUser { get; set; }
        public static Theme nowTheme { get; set; }
        public static List<ForumPost> newForumPosts
        {
            get
            {
                List<ForumPost> newForumPosts = new List<ForumPost>();
                ForumPostsLogic forumPostsLogic = new ForumPostsLogic();
                foreach (var post in forumPostsLogic.GetPosts())
                {
                    if (post.themeId == nowTheme.id)
                    {
                        newForumPosts.Add(post);
                    }
                }
                return newForumPosts;
            }
        }
    }
}
