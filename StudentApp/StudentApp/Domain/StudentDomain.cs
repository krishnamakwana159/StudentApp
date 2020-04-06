using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace StudentApp.Domain
{
    public class StudentDomain : BaseDomain
    {
        public List<Student> GetStudent()
        {
            var reader = this.GetReader($"select * from Students");
            var students = new List<Student>();
            while(reader.Read())
            {
                var student = new Student();
                student.StudentId = Convert.ToInt32(reader["StudentId"]);
                //student.StudentName = (string)reader["StudentName"];
                student.Address = (string)reader["Address"];
                student.MobileNo = Convert.ToInt32(reader["MobileNo"]);
                student.EmailId = (string)reader["EmailId"];
                student.Name = (string)reader["Name"];
                student.FeeStatus = (int)reader["FeeStatus"];
                students.Add(student);
            }
            return students;
        }

        public void StudentAdd(Student student)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-S5TQEIB\SQLEXPRESS;Initial Catalog=StudentDb;Integrated Security=True;");
            SqlCommand sqlCommand = new SqlCommand($"spInsert", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@name",student.Name);
            sqlCommand.Parameters.AddWithValue("@address", student.Address); 
            sqlCommand.Parameters.AddWithValue("@mobNo", student.MobileNo);
            sqlCommand.Parameters.AddWithValue("@emailId", student.EmailId);
            sqlCommand.Parameters.AddWithValue("@course", student.CourseId);
            sqlCommand.Parameters.AddWithValue("@fee", student.FeeStatus);
            sqlCommand.ExecuteNonQuery();
        }

        public void StudentUpdate(Student student)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-S5TQEIB\SQLEXPRESS;Initial Catalog=StudentDb;Integrated Security=True;");
            SqlCommand sqlCommand = new SqlCommand($"spUpdate", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@studentId", student.Name);
            sqlCommand.Parameters.AddWithValue("@address", student.Address);
            sqlCommand.Parameters.AddWithValue("@mobNo", student.MobileNo);
            sqlCommand.Parameters.AddWithValue("@emailId", student.EmailId);
            sqlCommand.Parameters.AddWithValue("@course", student.CourseId);
            sqlCommand.Parameters.AddWithValue("@fee", student.FeeStatus);
            sqlCommand.ExecuteNonQuery();
        }
        public void StudentDelete(int id)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-S5TQEIB\SQLEXPRESS;Initial Catalog=StudentDb;Integrated Security=True;");
            SqlCommand sqlCommand = new SqlCommand($"spDelete", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@studentId", id);
            sqlCommand.ExecuteNonQuery();
        }
    }
}
