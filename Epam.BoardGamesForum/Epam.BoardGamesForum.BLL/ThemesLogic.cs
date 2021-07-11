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

        public void DeleteTheme(Guid id)
        {
            ThemesSqlDAL.DeleteTheme(id);
        }

        public Theme GetTheme(Guid id)
        {
            Theme theme = ThemesSqlDAL.GetTheme(id);
            return theme;
        }

        public IEnumerable<Theme> GetThemes()
        {
            return ThemesSqlDAL.GetThemes();
        }
    }
}
