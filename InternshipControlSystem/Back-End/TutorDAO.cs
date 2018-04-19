using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using InternshipControlSystem.Model;

namespace InternshipControlSystem.Back_End
{
    class TutorDAO
    {
        public static List<Tutor> GetAllItems()
        {
            MySqlConnection conn = Conection.getConnection();
            List<Tutor> items = new List<Tutor>();
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM tutors";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Tutor item = new Tutor(Convert.ToInt32(reader["id"]), Convert.ToString(reader["first_name"]), Convert.ToString(reader["last_name"]));
                    items.Add(item);
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
            return items;
        }

        public static void CreateItem(Tutor tutor)
        {
            MySqlConnection conn = Conection.getConnection();
            try
            {
                conn.Open();
                string sqlStatement = "INSERT INTO tutors VALUES(null, @firstName, @lastName)";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@firstName", tutor.FirstName);
                cmd.Parameters.AddWithValue("@lastName", tutor.LastName);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void DeleteItem(int id)
        {
            MySqlConnection conn = Conection.getConnection();
            try
            {
                conn.Open();
                string sqlStatement = "DELETE FROM tutors WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public static void UpdateItem(Tutor tutor)
        {
            MySqlConnection conn = Conection.getConnection();
            try
            {
                conn.Open();
                string sqlStatement = "UPDATE tutors set first_name=@firstName, last_name=@lastName WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", tutor.Id);
                cmd.Parameters.AddWithValue("@firstName", tutor.FirstName);
                cmd.Parameters.AddWithValue("@lastName", tutor.LastName);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }


        public static Tutor GetItem(int id)
        {
            MySqlConnection conn = Conection.getConnection();
            Tutor item = null;
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM tutors WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new Tutor(Convert.ToInt32(reader["id"]), Convert.ToString(reader["first_name"]), Convert.ToString(reader["last_name"]));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return item;
        }
    }
}
