using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternshipControlSystem.Model;
using MySql.Data.MySqlClient;
using InternshipControlSystem.Front_End;
namespace InternshipControlSystem.Back_End
{
    class StudentsDAO
    {
        public static List<Student> GetAllItems()
        {
            MySqlConnection conn = Conection.getConnection();
            List<Student> students = new List<Student>();
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM students";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student(Convert.ToInt32(reader["id"]), Convert.ToString(reader["control_id"]),
                        Convert.ToString(reader["first_name"]), Convert.ToString(reader["last_name"]), Convert.ToString(reader["career"]), 
                        Convert.ToInt32(reader["semester"]), Convert.ToString(reader["cordinator"]),
                         Convert.ToString(reader["SocialSecurity"]), Convert.ToString(reader["Home"]), Convert.ToString(reader["Email"])
                         ,Convert.ToString(reader["City"]), Convert.ToString(reader["Phonehouse"]), Convert.ToInt32(reader["NumberInsurance"])
                         , Convert.ToString(reader["Phone"]), Convert.ToInt32(reader["company_id"]));
                    students.Add(student);
                }
                reader.Close();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return students;
        }

        public static void CreateItem(Student student){
            MySqlConnection conn = Conection.getConnection();
            try{
                conn.Open();
                string sqlStatement = "INSERT INTO students VALUES(null, @controlId, @firstName, @lastName, @career, @semester, @coordinator, @SocialSecurity, @Home, @Email, @City, @Phonehouse, @NumberInsurance, @Phone,@company_id)";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@controlId", student.Control_id);
                cmd.Parameters.AddWithValue("@firstName", student.First_name);
                cmd.Parameters.AddWithValue("@lastName", student.Last_name);
                cmd.Parameters.AddWithValue("@career", student.Career);
                cmd.Parameters.AddWithValue("@semester", student.Semester);
                cmd.Parameters.AddWithValue("@coordinator", student.Cordinator);             
                cmd.Parameters.AddWithValue("@SocialSecurity", student.SocialSecurityDao);
                cmd.Parameters.AddWithValue("@Home", student.HomeDao);
                cmd.Parameters.AddWithValue("@Email", student.EmailDao);
                cmd.Parameters.AddWithValue("@City", student.CityDao);
                cmd.Parameters.AddWithValue("@Phonehouse", student.PhonehouseDao);
                cmd.Parameters.AddWithValue("@NumberInsurance", student.NumberInsuranceDao);
                cmd.Parameters.AddWithValue("@Phone", student.PhoneDao);
                cmd.Parameters.AddWithValue("@company_id", student.PhoneDao);
                cmd.ExecuteNonQuery();
            }catch (Exception ex){
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
            }finally{
                conn.Close();
            }
        }

        public static void DeleteItem(int id){
            MySqlConnection conn = Conection.getConnection();
            try{
                conn.Open();
                string sqlStatement = "DELETE FROM students WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }catch(Exception ex){
                Console.WriteLine(ex.ToString());
            }finally{
                conn.Close();
            }
        }

        public static void UpdateItem(Student student){
            MySqlConnection conn = Conection.getConnection();
            try{
                conn.Open();
                string sqlStatement = "UPDATE students set control_id=@controlId, first_name=@firstName, last_name=@lastName," +
                    "career=@career, semester=@semester, cordinator=@coordinator, tutor_id=@tutorId WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", student.Id);
                cmd.Parameters.AddWithValue("@controlId", student.Control_id);
                cmd.Parameters.AddWithValue("@firstName", student.First_name);
                cmd.Parameters.AddWithValue("@lastName", student.Last_name);
                cmd.Parameters.AddWithValue("@career", student.Career);
                cmd.Parameters.AddWithValue("@semester", student.Semester);
                cmd.Parameters.AddWithValue("@coordinator", student.Cordinator);
                cmd.Parameters.AddWithValue("@tutorId", student.Tutor_id);
                cmd.ExecuteNonQuery();
            }catch (Exception ex){
                Console.WriteLine(ex.ToString());
            }finally{
                conn.Close();
            }
        }       


        public static Student GetItem(int id)
        {
            MySqlConnection conn = Conection.getConnection();
            Student student = null;
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM students WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    student = new Student(Convert.ToInt32(reader["id"]), Convert.ToString(reader["control_id"]),
                        Convert.ToString(reader["first_name"]), Convert.ToString(reader["last_name"]), Convert.ToString(reader["career"]),
                        Convert.ToInt32(reader["semester"]), Convert.ToString(reader["cordinator"]),
                        Convert.ToString(reader["SocialSecurity"]), Convert.ToString(reader["Home"]), Convert.ToString(reader["Email"])
                         , Convert.ToString(reader["City"]), Convert.ToString(reader["Phonehouse"]), Convert.ToInt32(reader["NumberInsurance"])
                         , Convert.ToString(reader["Phone"]),Convert.ToInt32(reader["company_id"]));
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return student;
        }
    }
}
