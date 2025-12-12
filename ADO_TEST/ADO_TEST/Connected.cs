using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_TEST
{
    internal class Connected
    {
        // TASK 2.1
        public void DisplayCourse()
        {
            SqlConnection con = new SqlConnection("Integrated security = true;database = ADO_TEST;server = (localdb)\\MSSQLLocalDB");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Courses",con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"{dr["CourseId"]}   {dr["CourseName"]}   {dr["Credits"]}    {dr["Semester"]} ");
            }
            con.Close();
        }

        // TASK 2.2
        public void AddNewStudent()
        {

            SqlConnection con = new SqlConnection("Integrated security = true;database = ADO_TEST;server = (localdb)\\MSSQLLocalDB");
            con.Open();

            Console.Write("Enter Student Name: ");
            string FullName = Console.ReadLine();

            Console.Write("Enter Email ID: ");
            string Email = Console.ReadLine();

            Console.Write("Enter Department Name: ");
            string Department = Console.ReadLine();

            Console.Write("Enter Year of Study: ");
            int YearOfstudy = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd = new SqlCommand("insert into Students(FullName,Email,Department,YearOfStudy)values(@FullName,@Email,@Department,@YearOfStudy)", con);

            cmd.Parameters.AddWithValue("@FullName", FullName);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Department", Department);
            cmd.Parameters.AddWithValue("@YearOfStudy", YearOfstudy);

            int rowaffected = cmd.ExecuteNonQuery();
            Console.WriteLine(rowaffected + "record inserted");
            con.Close();
        }
        // TASK 2.3
        public void SearchStudent(string Department)
        {
            SqlConnection con = new SqlConnection("Integrated security = true;database = ADO_TEST;server = (localdb)\\MSSQLLocalDB");
            con.Open();

            SqlCommand cmd = new SqlCommand("select StudentId , FullName ,Email from Students where Department = @Department", con);

            cmd.Parameters.AddWithValue("@Department", Department);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"{dr["StudentId"]}   {dr["FullName"]}   {dr["Email"]} ");
            }
            con.Close();
        }

         // TASK 2.4
         public void DisplayEnrolledCourses(int studentId)
         {
            SqlConnection con = new SqlConnection("Integrated security = true;database = ADO_TEST;server = (localdb)\\MSSQLLocalDB");
            con.Open();

            SqlCommand cmd = new SqlCommand("select c.CourseName, c.Credits, e.EnrollDate, e.Grade FROM Enrollments e INNER JOIN Courses c ON e.CourseId = c.CourseId WHERE e.StudentId = @StudentId", con);

            cmd.Parameters.AddWithValue("@StudentId", studentId);


            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"{dr["CourseName"]}   {dr["Credits"]}   {dr["EnrollDate"]}   {dr["Grade"]} ");
            }
            con.Close();
         }

        // TASK 2.5

        public void UpdateGrade(int EnrollmentId,string Grade)
        {
            SqlConnection con = new SqlConnection("Integrated security = true;database = ADO_TEST;server = (localdb)\\MSSQLLocalDB");
            con.Open();

            SqlCommand cmd = new SqlCommand("update Enrollments set Grade = @Grade where EnrollmentId = @EnrollmentId", con);

            cmd.Parameters.AddWithValue("@EnrollmentId", EnrollmentId);
            cmd.Parameters.AddWithValue("@Grade", Grade);

            int rowaffected = cmd.ExecuteNonQuery();
            Console.WriteLine(rowaffected + " rows updated the grade");
            con.Close();
        }

        public void GetCourseBySem()
        {
            SqlConnection con = new SqlConnection("Integrated security = true;database = ADO_TEST;server = (localdb)\\MSSQLLocalDB");
            Console.WriteLine("Enter Semester: ");
            string sem = Console.ReadLine();

            con.Open();
            SqlCommand cmd = new SqlCommand("usp_getcoursesbysemester", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@Semester", sem);
            cmd.Parameters.Add(p1);

            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("Course details by semester: ");
            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]}\t{dr[1]}\t{dr[2]}");
            }
            con.Close();

        }
    }
}
