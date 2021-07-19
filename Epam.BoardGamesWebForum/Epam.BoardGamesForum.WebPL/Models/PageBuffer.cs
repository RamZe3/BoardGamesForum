using Epam.BoardGamesForum.Entities;
using System;
using System.Collections.Generic;
using Epam.BoardGamesForum.BLL;
using System.Text;
using System.Linq;
using NLog;

namespace Epam.BoardGamesForum.WebPL.Models
{
    public static class PageBuffer
    {
        public static Logger logger { get; set; } = LogManager.GetCurrentClassLogger();
        public static User nowUser { get; set; }

        public static User nowauthor { get; set; }
        public static Theme nowTheme { get; set; }

        public static ForumPost addForumPost { get; set; }

        public static IOrderedEnumerable<ForumPost> newForumPosts
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

                var sortedNewForumPosts = from post in newForumPosts
                                          orderby post.publicationDate
                                          select post;
                return sortedNewForumPosts;
            }
        }
    }
}
