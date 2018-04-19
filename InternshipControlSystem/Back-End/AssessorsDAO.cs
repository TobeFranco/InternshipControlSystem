using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using InternshipControlSystem.Model;
namespace InternshipControlSystem.Back_End
{
    class AssessorsDAO
    {
        public static List<Assessor> GetAllItems()
        {
            MySqlConnection conn = Conection.getConnection();
            List<Assessor> assessors = new List<Assessor>();
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM assessors";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Assessor assessor = new Assessor(Convert.ToInt32(reader["id"]),
                        Convert.ToString(reader["first_name"]), Convert.ToString(reader["last_name"])
                     );
                    assessors.Add(assessor);
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
            return assessors;
        }

        public static Assessor GetItem(int id)
        {
            MySqlConnection conn = Conection.getConnection();
            Assessor item = null;
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM assessors WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new Assessor(Convert.ToInt32(reader["id"]), Convert.ToString(reader["first_name"]), Convert.ToString(reader["last_name"]));
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


        public static void CreateItem(Assessor assessor)
        {
            MySqlConnection conn = Conection.getConnection();
            try
            {
                conn.Open();
                string sqlStatement = "INSERT INTO assessors VALUES(null,@first_name, @last_name)";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
              
                cmd.Parameters.AddWithValue("@first_name", assessor.FirstName);
                cmd.Parameters.AddWithValue("@last_name", assessor.LastName);
               
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
                string sqlStatement = "DELETE FROM assessors WHERE id = @id";
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

        public static void UpdateItem(Assessor assessor)
        {
            MySqlConnection conn = Conection.getConnection();
            try
            {
                conn.Open();
                string sqlStatement = "UPDATE assessors set id=@id, first_name=@first_name, last_name=@last_name";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", assessor.Id);
                cmd.Parameters.AddWithValue("@first_name", assessor.FirstName);
                cmd.Parameters.AddWithValue("@last_name", assessor.LastName);
              
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


    }
}
