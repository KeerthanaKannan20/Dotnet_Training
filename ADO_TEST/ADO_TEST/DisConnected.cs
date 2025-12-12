using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_TEST
{
    internal class DisConnected
    {


        private string connection = "Integrated Security = true;MultipleActiveResultSets=true; database = ADO_TEST; server =(localdb)\\MSSQLLocalDB";

        private DataSet ds = new DataSet();
        private SqlDataAdapter daStudent;
        private SqlDataAdapter daCourses;
        private DataTable dt = new DataTable();
        private DataTable dt2 = new DataTable();


        public void Dis()
        {
            SqlConnection con = new SqlConnection(connection);
            daStudent = new SqlDataAdapter("Select * from Students", con);
            daCourses = new SqlDataAdapter("Select * from Courses ", con);

            daStudent.Fill(ds, "Students");
            daCourses.Fill(ds, "Courses");

            daStudent.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daCourses.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            SqlCommandBuilder cb = new SqlCommandBuilder(daStudent);
            SqlCommandBuilder cb1 = new SqlCommandBuilder(daCourses);

        }

        // 3.1
        public void LoadData()
        {

            Console.WriteLine("Students Table: ");
            dt = ds.Tables["Students"];
            foreach (DataRow r in dt.Rows)
            {
                Console.WriteLine($"{r[0]}\t{r[1]}\t{r[2]}\t{r[3]}");
            }
        }

        //3.2
        public void Modify()
        {
            Console.WriteLine("Enter CourseID to Update credits: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Credits: ");
            int credits = int.Parse(Console.ReadLine());

            dt2 = ds.Tables["Courses"];
            DataRow row = dt2.Rows.Find(id);

            if (row != null)
            {
                row["Credits"] = credits;

                daCourses.Update(ds, "Courses");
                Console.WriteLine("Course credits updated successfully.");

            }
            else
            {
                Console.WriteLine("Course not found");
            }

        }

        // 3.3
        public void InsertNewCourse()
        {


            Console.WriteLine("Course Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Credits: ");
            int credits = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Semester: ");
            string sem = Console.ReadLine();

            dt2 = ds.Tables["Courses"];
            DataRow newRow = dt2.NewRow();

            newRow["CourseName"] = name;
            newRow["Credits"] = credits;
            newRow["Semester"] = sem;

            dt2.Rows.Add(newRow);
            daCourses.Update(ds, "Courses");

            Console.WriteLine("New course inserted Successfully.");

        }

        // 3.4
        public void DeleteStudent()
        {
            Console.WriteLine("Enter student Id to delete: ");
            int id = int.Parse(Console.ReadLine());

            dt = ds.Tables["Students"];
            DataRow row = dt.Rows.Find(id);
            if (row != null)
            {
                row.Delete();
                daStudent.Update(ds, "Students");
                Console.WriteLine("Student Record Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Student not found");
            }

        }

    }
}
