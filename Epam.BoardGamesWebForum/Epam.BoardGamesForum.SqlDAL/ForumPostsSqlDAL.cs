using Epam.BoardGamesForum.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Epam.BoardGamesForum.DAL.Interfaces;
using System.Configuration;

namespace Epam.BoardGamesForum.SqlDAL
{
    public class ForumPostsSqlDAL : IForumPostsDAL
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

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



        public ForumPost GetPost(Guid id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var stProc = "ForumPosts_GetById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new ForumPost(
                        id: (Guid)reader["Id"],
                        text: reader["Text"] as string,
                       publicationDate: (DateTime)reader["PublicationDate"],
                       authorId: (Guid)reader["AuthorId"],
                       themeId: (Guid)reader["ThemeId"]);
                }
                _connection.Close();

                throw new InvalidOperationException("Cannot find User with ID = " + id);
            }
        }

        public void EditPost(Guid id, string newText)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = $"UPDATE dbo.ForumPosts SET Text='{newText}'" +
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
