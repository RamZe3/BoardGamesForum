using Epam.BoardGamesForum.BLL;
using Epam.BoardGamesForum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Epam.BoardGamesForum.WebPL.Models
{
    public class UserRollProv : RoleProvider
    {
        private UsersLogic _usersLogic { get; } = new UsersLogic();
        public override bool IsUserInRole(string username, string roleName)
        {
            User user = _usersLogic.GetUser(username);
            return (username == "admin")||(user.role == roleName);
        }

        public void AddUserToRole(string username, string roleName)
        {
            User user = _usersLogic.GetUser(username);
            user.role = roleName;
        }

        public void RemoveUserFromRole(string username, string roleName)
        {
            User user = _usersLogic.GetUser(username);
            if (user.role == roleName)
            {
                user.role = "user";
            }
        }

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            User user = _usersLogic.GetUser(username);
            return new[] { user.role };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}