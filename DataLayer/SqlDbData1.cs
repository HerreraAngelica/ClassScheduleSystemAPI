using Models1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SqlDbData
    {
        string connectionString = "Data Source=ANGELICA\\SQLEXPRESS02; Initial Catalog=ClassScheduleManagementAPI; Integrated Security=True;";
        SqlConnection sqlConnection;


        public SqlDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<Schedule> GetSchedules()
        {
            string selectStatement = "SELECT * FROM dbo.sched";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            List<Schedule> sched = new List<Schedule>();

            while (reader.Read())
            {
                string Classes = reader["Class"].ToString();
                string Day = reader["Day"].ToString();
                string Subject = reader["Subject"].ToString();
                string Time = reader["Time"].ToString();
                string Professor = reader["Profesor"].ToString();


                Schedule readUser = new Schedule();
                readUser.Classes = Classes;
                readUser.Day = Day;
                readUser.Subject = Subject;
                readUser.Time = Time;
                readUser.Professor = Professor;

                sched.Add(readUser);
            }

            sqlConnection.Close();
            return sched;
        }

        public void AddSchedule(string Classes, string Day, string Subject, string Time, string Professor)
        {
            string insertStatement = "INSERT INTO dbo.sched (Class, Day, Subject, Time, Profesor) VALUES (@Classes, @Day, @Subject, @Time, @Professor)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@Classes", Classes);
            insertCommand.Parameters.AddWithValue("@Day", Day);
            insertCommand.Parameters.AddWithValue("@Subject", Subject);
            insertCommand.Parameters.AddWithValue("@Time", Time);
            insertCommand.Parameters.AddWithValue("@Professor", Professor);

            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }

        public void DeleteSchedule(string Classes, string Subject, string Professor)
        {
            string deleteStatement = "DELETE FROM dbo.sched WHERE Class = @Classes AND Subject = @Subject  AND Profesor = @Professor";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);

            deleteCommand.Parameters.AddWithValue("@Classes", Classes);
            deleteCommand.Parameters.AddWithValue("@Subject", Subject);
            deleteCommand.Parameters.AddWithValue("@Professor", Professor);

            sqlConnection.Open();

            deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }


        public List<Schedule> GetSchedulesForDay(string Day, string Subject, string Professor)
        {
            string selectStatement = "SELECT * FROM dbo.sched WHERE Day = @Day AND Subject = @Subject AND Profesor = @Professor";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            selectCommand.Parameters.AddWithValue("@Day", Day);
            selectCommand.Parameters.AddWithValue("@Subject", Subject);
            selectCommand.Parameters.AddWithValue("@Professor", Professor);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            List<Schedule> schedules = new List<Schedule>();

            while (reader.Read())
            {
                Schedule schedule = new Schedule
                {
                    Classes = reader["Classes"].ToString(),
                    Day = reader["Day"].ToString(),
                    Subject = reader["Subject"].ToString(),
                    Time = reader["Time"].ToString(),
                    Professor = reader["Professor"].ToString()
                };
                schedules.Add(schedule);
            }

            sqlConnection.Close();
            return schedules;
        }

        public void UpdateSchedule(string Classes, string Day)
        {
            string updateStatement = "UPDATE Classes SET Day = @Day WHERE Class = @Classes";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@Classes", Classes);
            updateCommand.Parameters.AddWithValue("@Day", Day);
            sqlConnection.Open();

            updateCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }

}