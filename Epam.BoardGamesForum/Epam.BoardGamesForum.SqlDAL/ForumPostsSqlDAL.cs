using Epam.BoardGamesForum.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Epam.BoardGamesForum.SqlDAL
{
    public class ForumPostsSqlDAL
    {
        public string _connectionString = @"Data Source=DESKTOP-SL9L2I0\SQLEXPRESS;Initial Catalog=UsersTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public ForumPost AddPost(ForumPost forumPost)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.ForumPosts(Id, Text, PublicationDate, AuthorId, ThemeId) " +
                    "VALUES(@Id, @Text, @PublicationDate, @AuthorId, @ThemeId)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id", forumPost.id);
                command.Parameters.AddWithValue("@Text", forumPost.text);
                command.Parameters.AddWithValue("@PublicationDate", forumPost.publicationDate);
                command.Parameters.AddWithValue("@AuthorId", forumPost.authorId);
                command.Parameters.AddWithValue("@ThemeId", forumPost.themeId);

                _connection.Open();

                command.ExecuteNonQuery();

                _connection.Close();

                return new ForumPost(
                        id: forumPost.id,
                        text: forumPost.text,
                        publicationDate: forumPost.publicationDate,
                        authorId: forumPost.authorId,
                        themeId: forumPost.themeId);
            }
        }

        public void DeletePost(Guid id)
        {
            string sql = $"Delete From ForumPosts Where Id='{id}'";
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(sql, _connection);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }

        }

        public IEnumerable<ForumPost> GetPosts()
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Id, Text, PublicationDate, AuthorId, ThemeId FROM ForumPosts";

                var command = new SqlCommand(query, _connection);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new ForumPost(
                        id: (Guid)reader["Id"],
                        text: reader["Text"] as string,
                       publicationDate: (DateTime)reader["PublicationDate"],
                       authorId: (Guid)reader["AuthorId"],
                       themeId: (Guid)reader["ThemeId"]);
                }
                _connection.Close();
            }
        }


        //TODO
        /*
        public User GetPost(Guid id)
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
        */
    }
}
