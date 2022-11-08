using System.Data.SqlClient;
using H4LoginAPI.Model;
namespace H4LoginAPI.Database
{
    public class DataAccess
    {
        const string ConnString = "Server=DESKTOP-HT94JHQ\\SQLEXPRESS;Database=H4Login;Trusted_Connection=True;";
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;

        public void RegisterUser(User user)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                conn.Open();
                cmd = new SqlCommand("INSERT INTO LoginForm VALUES(@username, @password, @salt)", conn);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@salt", user.Salt);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        public User Login(string username)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM LoginForm Where Username = @username", conn);
                cmd.Parameters.AddWithValue("@username", username);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    User user = new User((string)reader["Username"], (string)reader["HashPassword"], (string)reader["Salt"]);
                    conn.Close();
                    return user;
                }
                conn.Close();
                return null;

            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        public void UpdatePassWord(string username, string password, string salt)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                conn.Open();
                cmd = new SqlCommand("UPDATE LoginForm SET Salt = @salt, HashPassword = @password WHERE Username = @username", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@salt", salt);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
