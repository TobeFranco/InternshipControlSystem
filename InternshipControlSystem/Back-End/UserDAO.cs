using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace InternshipControlSystem.Back_End
{
  public  class UserDAO
    {
        public static int GetID(int IdUser, String Type)
        {
            MySqlConnection conn = Conection.getConnection();
            try
            {
                conn.Open();
                string sqlStatement = "SELECT UserID FROM @Type WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@id", IdUser);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["UserID"]);
                }
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1; 
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
