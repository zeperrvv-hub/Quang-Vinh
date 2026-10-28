
using System;
using System.Security.Cryptography;
using Npgsql;

namespace BaiTap4_1
{
    public class DatabaseHelper
    {
        private const string ConnectionString =
            "Host=localhost;Port=5432;Database=login_db;Username=postgres;Password=YOUR_POSTGRES_PASSWORD";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }

        public static string HashPassword(string password)
        {
            byte[] salt = new byte[16];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(
                password, salt, 100000))
            {
                byte[] hash = pbkdf2.GetBytes(32);

                return Convert.ToBase64String(salt) + ":" +
                    Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPassword(
            string password, string savedHash)
        {
            try
            {
                string[] parts = savedHash.Split(':');

                if (parts.Length != 2)
                    return false;

                byte[] salt = Convert.FromBase64String(parts[0]);
                byte[] expected = Convert.FromBase64String(parts[1]);

                using (var pbkdf2 = new Rfc2898DeriveBytes(
                    password, salt, 100000))
                {
                    byte[] actual = pbkdf2.GetBytes(32);

                    if (actual.Length != expected.Length)
                        return false;

                    int difference = 0;

                    for (int i = 0; i < actual.Length; i++)
                        difference |= actual[i] ^ expected[i];

                    return difference == 0;
                }
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static void InitializeDatabase()
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"
                    CREATE TABLE IF NOT EXISTS users (
                        id SERIAL PRIMARY KEY,
                        username VARCHAR(50) UNIQUE NOT NULL,
                        password_hash TEXT NOT NULL,
                        created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                    );";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                string checkSql =
                    "SELECT COUNT(*) FROM users WHERE username = @u";

                using (var cmd = new NpgsqlCommand(checkSql, conn))
                {
                    cmd.Parameters.AddWithValue("u", "admin");

                    long count = (long)cmd.ExecuteScalar();

                    if (count == 0)
                    {
                        string insertSql = @"
                            INSERT INTO users(username, password_hash)
                            VALUES (@u, @p)";

                        using (var insert = new NpgsqlCommand(
                            insertSql, conn))
                        {
                            insert.Parameters.AddWithValue(
                                "u", "admin");

                            insert.Parameters.AddWithValue(
                                "p", HashPassword("Admin@123"));

                            insert.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static bool Login(string username, string password)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql =
                    "SELECT password_hash FROM users WHERE username = @u";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("u", username);

                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                        return false;

                    return VerifyPassword(password, result.ToString());
                }
            }
        }

        public static bool Register(string username, string password)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO users(username, password_hash)
                    VALUES (@u, @p)
                    ON CONFLICT (username) DO NOTHING";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("u", username);
                    cmd.Parameters.AddWithValue(
                        "p", HashPassword(password));

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }
    }
}
