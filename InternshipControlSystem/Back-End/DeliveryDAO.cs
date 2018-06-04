using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using InternshipControlSystem.Model;

namespace InternshipControlSystem.Back_End
{
    class DeliveryDAO
    {
        public static List<Delivery> GetAllItems()
        {
            MySqlConnection conn = Conection.getConnection();
            List<Delivery> items = new List<Delivery>();
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM student_deliveries";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Delivery item = new Delivery(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["student_id"]), 
                        Convert.ToString(reader["del_type"]), Convert.ToBoolean(reader["delivered"]));
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

        public static void CreateItem(Delivery item)
        {
            MySqlConnection conn = Conection.getConnection();
            try
            {
                conn.Open();
                string sqlStatement = "INSERT INTO student_deliveries VALUES(null, @student_id, @delivery_type, @delivered)";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@student_id", item.Student_Id);
                cmd.Parameters.AddWithValue("@delivery_type", item.Delivery_type);
                cmd.Parameters.AddWithValue("@delivered", item.Delivered);
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
                string sqlStatement = "DELETE FROM student_deliveries WHERE id = @id";
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

        public static void UpdateItem(Delivery item)
        {
            MySqlConnection conn = Conection.getConnection();
            try
            {
                conn.Open();
                string sqlStatement = "UPDATE student_deliveries set student_id=@student_id, del_type=@delivery_type, delivered=@delivered WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.Parameters.AddWithValue("@student_id", item.Student_Id);
                cmd.Parameters.AddWithValue("@delivery_type", item.Delivery_type);
                cmd.Parameters.AddWithValue("@delivered", item.Delivered);
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


        public static Delivery GetItem(int id)
        {
            MySqlConnection conn = Conection.getConnection();
            Delivery item = null;
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM student_deliveries WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new Delivery(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["student_id"]), 
                        Convert.ToString(reader["del_type"]), Convert.ToBoolean(reader["delivered"]));
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

        public static List<Delivery> GetAllItemsFromStudent(Student student)
        {
            MySqlConnection conn = Conection.getConnection();
            List<Delivery> items = new List<Delivery>();
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM student_deliveries WHERE student_id=@id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", student.Id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Delivery item = new Delivery(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["student_id"]), 
                        Convert.ToString(reader["del_type"]), Convert.ToBoolean(reader["delivered"]));
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
    }
}
