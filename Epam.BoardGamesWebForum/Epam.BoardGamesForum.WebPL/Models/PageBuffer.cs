using Epam.BoardGamesForum.Entities;
using System;
using System.Collections.Generic;
using Epam.BoardGamesForum.BLL;
using System.Text;
using System.Linq;
using NLog;
using Epam.BoardGamesForum.BLL.Interfaces;
using Epam.BoardGamesWebForum.Dependencies;

namespace Epam.BoardGamesForum.WebPL.Models
{
    public static class PageBuffer
    {
        public static IForumPostsLogic forumPostsBLL = DependenciesResolver.Instance.ForumPostsLogic;
        public static IThemesLogic themesBLL = DependenciesResolver.Instance.ThemesLogic;
        public static IUsersLogic usersBLL = DependenciesResolver.Instance.UsersLogic;

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
                foreach (var post in forumPostsBLL.GetPosts())
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
