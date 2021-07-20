using Epam.BoardGamesForum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.BoardGamesForum.BLL.Interfaces
{
    public interface IThemesLogic
    {
        void AddTheme(string name);
        void DeleteTheme(string name);
        Theme GetTheme(string name);
        IEnumerable<Theme> GetThemes();
        void EditTheme(string name, string newName);
    }
}
