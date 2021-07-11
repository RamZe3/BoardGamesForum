using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.BoardGamesForum.Entities
{
    public class Theme
    {
        public Guid id { get; set; }
        public string name { get; set; }

        public Theme(Guid id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
