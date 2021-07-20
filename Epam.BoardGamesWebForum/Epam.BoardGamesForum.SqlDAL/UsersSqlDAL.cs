using Epam.BoardGamesForum.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Epam.BoardGamesForum.DAL.Interfaces;

namespace Epam.BoardGamesForum.SqlDAL
{
    public class UsersSqlDAL : IUsersDAL
    {
        private string _connectionString = @"Data Source=DESKTOP-SL9L2I0\SQLEXPRESS;Initial Catalog=UsersTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public User AddUser(User user)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Users(Id, Login, HashOfPass, Role) " +
                    "VALUES(@Id, @Login, @HashOfPass, @Role)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id", user.id);
                command.Parameters.AddWithValue("@Login", user.login);
                command.Parameters.AddWithValue("@HashOfPass", user.hashOfPass);
                command.Parameters.AddWithValue("@Role", user.role);

                _connection.Open();

                command.ExecuteNonQuery();

                _connection.Close();

                return new User(
                        id: user.id,
                        login: user.login,
                        hashOfPass: user.hashOfPass,
                        role: user.role);
            }
        }

        public void DeleteUser(Guid id)
        {
            string sql = $"Delete From Users Where Id='{id}'";
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(sql, _connection);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }

        }

        public IEnumerable<User> GetUsers()
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Id, Login, HashOfPass, Role FROM Users";

                var command = new SqlCommand(query, _connection);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User(
                        id: (Guid)reader["Id"],
                        login: reader["Login"] as string,
                       hashOfPass: reader["HashOfPass"] as string,
                       role: reader["Role"] as string);
                }
                _connection.Close();
            }
        }

        public User GetUser(Guid id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Users_GetById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new User(
                        id: (Guid)reader["Id"],
                        login: reader["Login"] as string,
                        hashOfPass: reader["HashOfPass"] as string,
                        role: reader["Role"] as string);
                }
                _connection.Close();

                throw new InvalidOperationException("Cannot find User with ID = " + id);
            }
        }

        public void EditUser(Guid id, Guid newId, string newLogin, string newHashOfPass)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = $"UPDATE dbo.Users SET Login='{newLogin}', HashOfPass='{newHashOfPass}', Id='{newId}'" +
                    $"WHERE Id = '{id}'";
                var command = new SqlCommand(query, _connection);

                try
                {
                    _connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    _connection.Close();
                }
            }
        }
    }
}
