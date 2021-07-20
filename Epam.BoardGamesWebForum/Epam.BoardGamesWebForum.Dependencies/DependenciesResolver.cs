using Epam.BoardGamesForum.BLL;
using Epam.BoardGamesForum.BLL.Interfaces;
using Epam.BoardGamesForum.DAL.Interfaces;
using Epam.BoardGamesForum.SqlDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.BoardGamesWebForum.Dependencies
{
    public class DependenciesResolver
    {
        private static DependenciesResolver _instance;
        public static DependenciesResolver Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new DependenciesResolver();
                }

                return _instance;
            }
        }

        public IForumPostsDAL ForumPostsDAL => new ForumPostsSqlDAL();
        public IThemesDAL ThemesDAL => new ThemesSqlDAL();
        public IUsersDAL UsersDAL => new UsersSqlDAL();

        public IForumPostsLogic ForumPostsLogic => new ForumPostsLogic(ForumPostsDAL);
        public IThemesLogic ThemesLogic => new ThemesLogic(ThemesDAL);
        public IUsersLogic UsersLogic => new UsersLogic(UsersDAL);
    }
}
