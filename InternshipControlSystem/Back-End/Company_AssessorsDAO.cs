using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternshipControlSystem.Model;
using MySql.Data.MySqlClient;

namespace InternshipControlSystem.Back_End
{
    class Company_AssessorsDAO
    {
        public static List<Company_Assessor> GetAllItems()
        {
            MySqlConnection conn = Conection.getConnection();
            List<Company_Assessor> items = new List<Company_Assessor>();
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM company_assessors";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Company_Assessor assessor = new Company_Assessor(Convert.ToInt32(reader["id"]),
                        Convert.ToString(reader["first_name"]), Convert.ToString(reader["last_name"])
                     );
                    items.Add(assessor);
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

        public static Company_Assessor GetItem(int id)
        {
            MySqlConnection conn = Conection.getConnection();
            Company_Assessor item = null;
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM company_assessors WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new Company_Assessor(Convert.ToInt32(reader["id"]), Convert.ToString(reader["first_name"]), Convert.ToString(reader["last_name"]));
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


        public static void CreateItem(Company_Assessor assessor)
        {
            MySqlConnection conn = Conection.getConnection();
            try
            {
                conn.Open();
                string sqlStatement = "INSERT INTO company_assessors VALUES(null,@first_name, @last_name)";
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
                string sqlStatement = "DELETE FROM company_assessors WHERE id = @id";
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

        public static void UpdateItem(Company_Assessor assessor)
        {
            MySqlConnection conn = Conection.getConnection();
            try
            {
                conn.Open();
                string sqlStatement = "UPDATE company_assessors set id=@id, first_name=@first_name, last_name=@last_name";
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
