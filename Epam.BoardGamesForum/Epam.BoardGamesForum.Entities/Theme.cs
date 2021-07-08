using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.BoardGamesForum.Entities
{
    public class Theme
    {
        public string id { get; set; }
        public string name { get; set; }

        public Theme(string id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
