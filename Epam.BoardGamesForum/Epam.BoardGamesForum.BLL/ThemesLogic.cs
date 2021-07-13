using Epam.BoardGamesForum.Entities;
using Epam.BoardGamesForum.SqlDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.BoardGamesForum.BLL
{
    public class ThemesLogic
    {
        ThemesSqlDAL ThemesSqlDAL = new ThemesSqlDAL();
        public void AddTheme(string name)
        {
            Guid id = HashGenerator.GenerateHash(name);
            Theme theme = new Theme(id, name);
            ThemesSqlDAL.AddTheme(theme);
        }

        public void DeleteTheme(string name)
        {
            Guid id = HashGenerator.GenerateHash(name);
            ThemesSqlDAL.DeleteTheme(id);

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
            Theme theme = ThemesSqlDAL.GetTheme(id);
            return theme;
        }

        public IEnumerable<Theme> GetThemes()
        {
            return ThemesSqlDAL.GetThemes();
        }

        public void EditTheme(string name, string newName)
        {
            Guid id = HashGenerator.GenerateHash(name);
            Guid newId = HashGenerator.GenerateHash(newName);
            ThemesSqlDAL.EditTheme(id, newId, newName);
        }
    }
}
