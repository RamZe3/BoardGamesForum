using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.BoardGamesForum.Entities
{
    public class User
    {
        public string id { get; set; }
        public string login { get; set; }
        public string hashOfPass { get; set; }

        public User(string id, string login, string lashOfPass)
        {
            this.id = id;
            this.login = login;
            this.hashOfPass = lashOfPass;
        }
    }
}
