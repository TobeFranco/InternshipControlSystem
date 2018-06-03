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
                        Convert.ToInt32(reader["semester"]), Convert.ToString(reader["cordinator"]), Convert.ToInt32(reader["tutor_id"]),
                         Convert.ToString(reader["socialSecurity"]), Convert.ToString(reader["home"]), Convert.ToString(reader["email"])
                         , Convert.ToString(reader["city"]), Convert.ToString(reader["phonehouse"]), Convert.ToInt32(reader["numberInsurance"])
                         , Convert.ToString(reader["phone"]), Convert.ToInt32(reader["company_id"]), Convert.ToInt32(reader["revisor1_id"]),
                         Convert.ToInt32(reader["revisor2_id"]), Convert.ToBoolean(reader["revisor1_approval"]), Convert.ToBoolean(reader["revisor2_approval"]),
                         Convert.ToBoolean(reader["tutor_approval"]), Convert.ToBoolean(reader["titulation_approval"]));
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






        public static List<Student> GetAllItemsInTutor(int id)
        {
            MySqlConnection conn = Conection.getConnection();
            List<Student> students = new List<Student>();
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM students where tutor_id=@tutor_id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@tutor_id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student(Convert.ToInt32(reader["id"]), Convert.ToString(reader["control_id"]),
                        Convert.ToString(reader["first_name"]), Convert.ToString(reader["last_name"]), Convert.ToString(reader["career"]),
                        Convert.ToInt32(reader["semester"]), Convert.ToString(reader["cordinator"]), Convert.ToInt32(reader["tutor_id"]),
                         Convert.ToString(reader["socialSecurity"]), Convert.ToString(reader["home"]), Convert.ToString(reader["email"])
                         , Convert.ToString(reader["city"]), Convert.ToString(reader["phonehouse"]), Convert.ToInt32(reader["numberInsurance"])
                         , Convert.ToString(reader["phone"]), Convert.ToInt32(reader["company_id"]),  Convert.ToInt32(reader["revisor1_id"]),
                         Convert.ToInt32(reader["revisor2_id"]), Convert.ToBoolean(reader["revisor1_approval"]), Convert.ToBoolean(reader["revisor2_approval"]),
                         Convert.ToBoolean(reader["tutor_approval"]), Convert.ToBoolean(reader["titulation_approval"]));
                    students.Add(student);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return students;
        }

        public static List<Student> GetAllItemsInRevisor(int id)
        {
            MySqlConnection conn = Conection.getConnection();
            List<Student> students = new List<Student>();
            List<int> studentsID = new List<int>();
            try
            {
                conn.Open();
                string sqlStatement = "SELECT student_ID FROM students_revisors where revisor_id=@revisor_id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@revisor_id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    studentsID.Add(Convert.ToInt32(reader["student_ID"]));
                }
                reader.Close();
                students = GetAllItemsInRevisor_Continue(studentsID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return students;
        }

        public static List<Student> GetAllItemsInRevisor_Continue(List<int> students)
        {
            MySqlConnection conn = Conection.getConnection();
            List<Student> studentsDetils = new List<Student>();
            try
            {
                conn.Open();
                foreach (var id in students)
                {
                    string sqlStatement = "SELECT * FROM students where revisor_id=@revisor_id";
                    MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                    cmd.Parameters.AddWithValue("@revisor_id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Student student = new Student(Convert.ToInt32(reader["id"]), Convert.ToString(reader["control_id"]),
                        Convert.ToString(reader["first_name"]), Convert.ToString(reader["last_name"]), Convert.ToString(reader["career"]),
                        Convert.ToInt32(reader["semester"]), Convert.ToString(reader["cordinator"]), Convert.ToInt32(reader["tutor_id"]),
                         Convert.ToString(reader["socialSecurity"]), Convert.ToString(reader["home"]), Convert.ToString(reader["email"])
                         , Convert.ToString(reader["city"]), Convert.ToString(reader["phonehouse"]), Convert.ToInt32(reader["numberInsurance"])
                         , Convert.ToString(reader["phone"]), Convert.ToInt32(reader["company_id"]), Convert.ToInt32(reader["revisor1_id"]),
                         Convert.ToInt32(reader["revisor2_id"]), Convert.ToBoolean(reader["revisor1_approval"]), Convert.ToBoolean(reader["revisor2_approval"]),
                         Convert.ToBoolean(reader["tutor_approval"]), Convert.ToBoolean(reader["titulation_approval"]));
                        studentsDetils.Add(student);
                    }
                }
                return studentsDetils;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return studentsDetils;
        }

        public static int CreateItem(Student student){
            MySqlConnection conn = Conection.getConnection();
            try{
                conn.Open();
                string sqlStatement = "INSERT INTO students VALUES(null, @controlId, @firstName, @lastName, @career, " +
                    "@semester, @coordinator, @Tutor_id, @SocialSecurity, @Home, @Email, @City, @Phonehouse, @NumberInsurance, " +
                    "@Phone,@company_id, @revisor1, @revisor2, @rev1_approval, @rev2_approval, @tutos_approval, @titulation_approval); " +
                    "SELECT LAST_INSERT_ID()";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@controlId", student.Control_id);
                cmd.Parameters.AddWithValue("@firstName", student.First_name);
                cmd.Parameters.AddWithValue("@lastName", student.Last_name);
                cmd.Parameters.AddWithValue("@career", student.Career);
                cmd.Parameters.AddWithValue("@semester", student.Semester);
                cmd.Parameters.AddWithValue("@coordinator", student.Cordinator);
                cmd.Parameters.AddWithValue("@Tutor_id", student.Tutor_id);
                cmd.Parameters.AddWithValue("@SocialSecurity", student.SocialSecurityDao);
                cmd.Parameters.AddWithValue("@Home", student.HomeDao);
                cmd.Parameters.AddWithValue("@Email", student.EmailDao);
                cmd.Parameters.AddWithValue("@City", student.CityDao);
                cmd.Parameters.AddWithValue("@Phonehouse", student.PhonehouseDao);
                cmd.Parameters.AddWithValue("@NumberInsurance", student.NumberInsuranceDao);
                cmd.Parameters.AddWithValue("@Phone", student.PhoneDao);
                cmd.Parameters.AddWithValue("@company_id", student.company_idDao);
                cmd.Parameters.AddWithValue("@revisor1", student.Revisor1_id);
                cmd.Parameters.AddWithValue("@revisor2", student.Revisor2_id);
                cmd.Parameters.AddWithValue("@rev1_approval", student.Revisor1_Approval);
                cmd.Parameters.AddWithValue("@rev2_approval", student.Revisor2_Approval);
                cmd.Parameters.AddWithValue("@tutor_approval", student.Tutor_Approval);
                cmd.Parameters.AddWithValue("@titulation_approval", student.Titulation_Approval);
                return cmd.ExecuteNonQuery();
            }catch (Exception ex){
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
                return -1;
            } finally{
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
                    "career=@career, semester=@semester, cordinator=@coordinator, tutor_id=@tutor_id, socialSecurity=@socialSecurity, " +
                    "home=@home, email=@email, city=@city, phonehouse=@phonehouse, numberInsurance=@numberInsurance, phone=@phone," +
                    "company_id=@company_id, revisor1_id=@revisor1, revisor2_id=@revisor2, revisor1_approval=@rev1_approval, " +
                    "revisor2_approval=@rev2_approval, tutor_approval=@tutor_approval, titulation_approval=@titulation_approval WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", student.Id);
                cmd.Parameters.AddWithValue("@controlId", student.Control_id);
                cmd.Parameters.AddWithValue("@firstName", student.First_name);
                cmd.Parameters.AddWithValue("@lastName", student.Last_name);
                cmd.Parameters.AddWithValue("@career", student.Career);
                cmd.Parameters.AddWithValue("@semester", student.Semester);
                cmd.Parameters.AddWithValue("@coordinator", student.Cordinator);
                cmd.Parameters.AddWithValue("tutor_id", student.Tutor_id);
                cmd.Parameters.AddWithValue("@socialSecurity", student.SocialSecurityDao);
                cmd.Parameters.AddWithValue("@home", student.HomeDao);
                cmd.Parameters.AddWithValue("@email", student.EmailDao);
                cmd.Parameters.AddWithValue("@city", student.CityDao);
                cmd.Parameters.AddWithValue("@phonehouse", student.PhonehouseDao);
                cmd.Parameters.AddWithValue("@numberInsurance", student.NumberInsuranceDao);
                cmd.Parameters.AddWithValue("@phone", student.PhoneDao);
                cmd.Parameters.AddWithValue("@company_id", student.company_idDao);
                cmd.Parameters.AddWithValue("@revisor1", student.Revisor1_id);
                cmd.Parameters.AddWithValue("@revisor2", student.Revisor2_id);
                cmd.Parameters.AddWithValue("@rev1_approval", student.Revisor1_Approval);
                cmd.Parameters.AddWithValue("@rev2_approval", student.Revisor2_Approval);
                cmd.Parameters.AddWithValue("@tutor_approval", student.Tutor_Approval);
                cmd.Parameters.AddWithValue("@titulation_approval", student.Titulation_Approval);
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
                        Convert.ToInt32(reader["semester"]), Convert.ToString(reader["cordinator"]), Convert.ToInt32(reader["tutor_id"]),
                         Convert.ToString(reader["socialSecurity"]), Convert.ToString(reader["home"]), Convert.ToString(reader["email"])
                         , Convert.ToString(reader["city"]), Convert.ToString(reader["phonehouse"]), Convert.ToInt32(reader["numberInsurance"])
                         , Convert.ToString(reader["phone"]), Convert.ToInt32(reader["company_id"]), Convert.ToInt32(reader["revisor1_id"]),
                         Convert.ToInt32(reader["revisor2_id"]), Convert.ToBoolean(reader["revisor1_approval"]), Convert.ToBoolean(reader["revisor2_approval"]),
                         Convert.ToBoolean(reader["tutor_approval"]), Convert.ToBoolean(reader["titulation_approval"]));
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
