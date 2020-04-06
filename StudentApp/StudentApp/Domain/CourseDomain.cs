using Microsoft.Data.SqlClient;
using StudentApp.Controller;
using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Domain
{
    public class CourseDomain : BaseDomain
    {
        public List<Course> GetCourse()
        {
            var reader = this.GetReader($"select * from Courses");
            var courses = new List<Course>();
            while (reader.Read())
            {
                var course = new Course();
                course.CourseId = Convert.ToInt32(reader["CourseId"]);
                course.Name = (string)reader["Name"];
                courses.Add(course);
            }
            return courses;
        }
        public void CourseAdd(Course course)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-S5TQEIB\SQLEXPRESS;Initial Catalog=StudentDb;Integrated Security=True;");
            SqlCommand sqlCommand = new SqlCommand($"spInsertCourse", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@name", course.Name);            
            sqlCommand.ExecuteNonQuery();
        }

        public void CourseUpdate(Course course)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-S5TQEIB\SQLEXPRESS;Initial Catalog=StudentDb;Integrated Security=True;");
            SqlCommand sqlCommand = new SqlCommand($"spUpdateCourse", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@courseId", course.CourseId);   
            sqlCommand.Parameters.AddWithValue("@name", course.Name);            
            sqlCommand.ExecuteNonQuery();
        }
        public void CourseDelete(int id)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-S5TQEIB\SQLEXPRESS;Initial Catalog=StudentDb;Integrated Security=True;");
            SqlCommand sqlCommand = new SqlCommand($"spDeleteCourse", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@courseId", id);
            sqlCommand.ExecuteNonQuery();
        }

    }
}
