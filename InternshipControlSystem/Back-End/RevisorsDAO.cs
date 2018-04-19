using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternshipControlSystem.Model;
using MySql.Data.MySqlClient;

namespace InternshipControlSystem.Back_End
{
    class RevisorsDAO
    {
        public static List<Revisor> GetAllItems()
        {
            MySqlConnection conn = Conection.getConnection();
            List<Revisor> items = new List<Revisor>();
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM revisors";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Revisor item = new Revisor(Convert.ToInt32(reader["id"]), Convert.ToString(reader["first_name"]), Convert.ToString(reader["last_name"]));
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

        public static void CreateItem(Revisor item)
        {
            MySqlConnection conn = Conection.getConnection();
            try
            {
                conn.Open();
                string sqlStatement = "INSERT INTO revisors VALUES(null, @firstName, @lastName)";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@firstName", item.FirstName);
                cmd.Parameters.AddWithValue("@lastName", item.LastName);
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
                string sqlStatement = "DELETE FROM revisors WHERE id = @id";
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

        public static void UpdateItem(Revisor item)
        {
            MySqlConnection conn = Conection.getConnection();
            try
            {
                conn.Open();
                string sqlStatement = "UPDATE revisors set first_name=@firstName, last_name=@lastName WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.Parameters.AddWithValue("@firstName", item.FirstName);
                cmd.Parameters.AddWithValue("@lastName", item.LastName);
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


        public static Revisor GetItem(int id)
        {
            MySqlConnection conn = Conection.getConnection();
            Revisor item = null;
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM revisors WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new Revisor(Convert.ToInt32(reader["id"]), Convert.ToString(reader["first_name"]), Convert.ToString(reader["last_name"]));
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
