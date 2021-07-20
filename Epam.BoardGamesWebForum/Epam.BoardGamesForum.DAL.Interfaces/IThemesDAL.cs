using Epam.BoardGamesForum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.BoardGamesForum.DAL.Interfaces
{
    public interface IThemesDAL
    {
        Theme AddTheme(Theme theme);
        void DeleteTheme(Guid id);
        IEnumerable<Theme> GetThemes();
        Theme GetTheme(Guid id);
        void EditTheme(Guid id, Guid newId, string newName);

    }
}
