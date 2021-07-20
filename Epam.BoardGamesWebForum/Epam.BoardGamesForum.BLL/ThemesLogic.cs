using Epam.BoardGamesForum.Entities;
using Epam.BoardGamesForum.SqlDAL;
using System;
using System.Collections.Generic;
using System.Text;
using Epam.BoardGamesForum.BLL.Interfaces;
using Epam.BoardGamesForum.DAL.Interfaces;

namespace Epam.BoardGamesForum.BLL
{
    public class ThemesLogic : IThemesLogic
    {
        //id = Hash of Name

        private IThemesDAL _ThemesDAL;

        public ThemesLogic(IThemesDAL themesDAL)
        {
            _ThemesDAL = themesDAL;
        }

        public void AddTheme(string name)
        {
            Guid id = HashGenerator.GenerateHash(name);
            Theme theme = new Theme(id, name);
            _ThemesDAL.AddTheme(theme);
        }

        public void DeleteTheme(string name)
        {
            Guid id = HashGenerator.GenerateHash(name);
            _ThemesDAL.DeleteTheme(id);

            ForumPostsSqlDAL forumPostsSqlDAL = new ForumPostsSqlDAL();
            foreach (var post in forumPostsSqlDAL.GetPosts())
            {
                if (post.themeId == id)
                {
                    forumPostsSqlDAL.DeletePost(post.id);
                }
            }
        }

        public Theme GetTheme(string name)
        {
            Guid id = HashGenerator.GenerateHash(name);
            Theme theme = _ThemesDAL.GetTheme(id);
            return theme;
        }

        public IEnumerable<Theme> GetThemes()
        {
            return _ThemesDAL.GetThemes();
        }

        public void EditTheme(string name, string newName)
        {
            Guid id = HashGenerator.GenerateHash(name);
            Guid newId = HashGenerator.GenerateHash(newName);
            _ThemesDAL.EditTheme(id, newId, newName);
        }
    }
}
