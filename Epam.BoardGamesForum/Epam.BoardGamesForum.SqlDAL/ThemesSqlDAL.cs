using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Epam.BoardGamesForum.Entities;

namespace Epam.BoardGamesForum.SqlDAL
{
    public class ThemesSqlDAL
    {
        public string _connectionString = @"Data Source=DESKTOP-SL9L2I0\SQLEXPRESS;Initial Catalog=UsersTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Theme AddTheme(Theme theme)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Themes(Id, Name) " +
                    "VALUES(@Id, @Name)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id", theme.id);
                command.Parameters.AddWithValue("@Name", theme.name);

                _connection.Open();

                command.ExecuteNonQuery();

                _connection.Close();

                return new Theme(
                        id: theme.id,
                        name: theme.name);
            }
        }

        public void DeleteTheme(Guid id)
        {
            string sql = $"Delete From Themes Where Id='{id}'";
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(sql, _connection);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }

        }

        public IEnumerable<Theme> GetThemes()
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Id, Name FROM Themes";

                var command = new SqlCommand(query, _connection);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Theme(
                        id: (Guid)reader["Id"],
                        name: reader["Name"] as string);
                }
                _connection.Close();
            }
        }

        public Theme GetTheme(Guid id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Themess_GetById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Theme(
                        id: (Guid)reader["Id"],
                        name: reader["Name"] as string);
                }
                _connection.Close();

                throw new InvalidOperationException("Cannot find Theme with ID = " + id);
            }
        }
    }
}
