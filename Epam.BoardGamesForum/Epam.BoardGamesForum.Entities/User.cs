using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.BoardGamesForum.Entities
{
    public class User
    {
        public Guid id { get; set; }
        public string login { get; set; }
        public string hashOfPass { get; set; }
        public string role { get; set; }

        public User(Guid id, string login, string hashOfPass, string role)
        {
            this.id = id;
            this.login = login;
            this.hashOfPass = hashOfPass;
            this.role = role;
        }

        public User(string login)
        {
            this.login = login;
        }
    }
}
