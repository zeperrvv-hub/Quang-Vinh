using System;
using System.Collections.Generic;
using Npgsql;

namespace BaiTap4_2
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }

    public class DatabaseHelper
    {
        private static string connectionString =
            "Host=localhost;Port=5432;Database=login_db;Username=postgres;Password=123456";

        public static List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>();

            using (NpgsqlConnection conn =
                new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql =
                    "SELECT course_id, course_name FROM courses ORDER BY course_id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        courses.Add(new Course
                        {
                            CourseId = reader.GetInt32(0),
                            CourseName = reader.GetString(1)
                        });
                    }
                }
            }

            return courses;
        }

        public static void SaveRegistration(
            string fullName,
            string phone,
            DateTime birthDate,
            string gender,
            int courseId,
            string studyMode)
        {
            using (NpgsqlConnection conn =
                new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                    INSERT INTO registrations
                    (full_name, phone, birth_date, gender, course_id, study_mode)
                    VALUES
                    (@name, @phone, @birthDate, @gender, @courseId, @studyMode)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", fullName);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@birthDate", birthDate.Date);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@courseId", courseId);
                    cmd.Parameters.AddWithValue("@studyMode", studyMode);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
