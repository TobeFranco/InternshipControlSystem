using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternshipControlSystem.Model;
using MySql.Data.MySqlClient;
namespace InternshipControlSystem.Back_End
{
    class CompanyDao
    {
        public static List<Company> GetAllItems()
        {
            MySqlConnection conn = Conection.getConnection();
            List<Company> items = new List<Company>();
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM companies ";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Company item = new Company(Convert.ToInt32(reader["id"]), Convert.ToString(reader["comp_name"]),
                        Convert.ToString(reader["RFC"]), Convert.ToString(reader["turn"]),
                         Convert.ToString(reader["companyHome"]), Convert.ToString(reader["companyColony"]), Convert.ToString(reader["cp"])
                         , Convert.ToString(reader["fax"]), Convert.ToString(reader["phoneCompany"]), Convert.ToString(reader["companyCity"]), Convert.ToString(reader["titularName"])
                         , Convert.ToString(reader["titularPosition"]), Convert.ToString(reader["advisoryName"]), Convert.ToString(reader["advisoryPosition"])
                         , Convert.ToString(reader["agreedName"]), Convert.ToString(reader["agreed"]));
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

        public static int CreateItem(Company item)
        {
            MySqlConnection conn = Conection.getConnection();
            try
            {
                conn.Open();
                string sqlStatement = "INSERT INTO companies VALUES(null, @comp_name, @RFC, @Turn, @CompanyHome, @CompanyColony, @Cp, @Fax, @PhoneCompany, @CompanyCity, @TitularName, @TitularPosition, @AdvisoryName, @AdvisoryPosition, @AgreedName, @Agreed); SELECT LAST_INSERT_ID()";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@comp_name", item.Name);
                cmd.Parameters.AddWithValue("@RFC", item.RFC);              
                cmd.Parameters.AddWithValue("@Turn", item.TurnDao);
                cmd.Parameters.AddWithValue("@CompanyHome", item.CompanyHomeDao);            
                cmd.Parameters.AddWithValue("@CompanyColony", item.CompanyColonyDao);
                cmd.Parameters.AddWithValue("@Cp", item.CPDao);
                cmd.Parameters.AddWithValue("@Fax", item.FAXDao);
                cmd.Parameters.AddWithValue("@PhoneCompany", item.PhoneCompanyDao);
                cmd.Parameters.AddWithValue("@CompanyCity", item.CompanyCityDao);
                cmd.Parameters.AddWithValue("@TitularName", item.TitularNameDao);
                cmd.Parameters.AddWithValue("@TitularPosition", item.TitularPositionDao);
                cmd.Parameters.AddWithValue("@AdvisoryName", item.AdvisoryNameDao);
                cmd.Parameters.AddWithValue("@AdvisoryPosition", item.AdvisoryPositionDao);
                cmd.Parameters.AddWithValue("@AgreedName", item.AgreedNameDao);
                cmd.Parameters.AddWithValue("@Agreed", item.AgreedDao);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
                return -1;
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
                string sqlStatement = "DELETE FROM companies WHERE id = @id";
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

        public static void UpdateItem(Company item)
        {
            MySqlConnection conn = Conection.getConnection();
            try
            {
                conn.Open();
                string sqlStatement = "UPDATE proyects set comp_name=@comp_name, RFC=@RFC, turn=@turn, companyHome=@CompanyHome, companyColony=@companyColony," +
                    "cp=@Cp, fax=@Fax, phoneCompany=@PhoneCompany, companyCity=@CompanyCity, titularName=@TitularName, titularPosition=@TitularPosition, " +
                    "advisoryName=@AdvisoryName, advisoryPosition=@AdvisoryPosition, agreedName=@AgreedName, agreed=@Agreed WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.Parameters.AddWithValue("@comp_name", item.Name);
                cmd.Parameters.AddWithValue("@RFC", item.RFC);
                cmd.Parameters.AddWithValue("@Turn", item.TurnDao);
                cmd.Parameters.AddWithValue("@CompanyHome", item.CompanyHomeDao);
                cmd.Parameters.AddWithValue("@CompanyColony", item.CompanyColonyDao);
                cmd.Parameters.AddWithValue("@Cp", item.CPDao);
                cmd.Parameters.AddWithValue("@Fax", item.FAXDao);
                cmd.Parameters.AddWithValue("@PhoneCompany", item.PhoneCompanyDao);
                cmd.Parameters.AddWithValue("@CompanyCity", item.CompanyCityDao);
                cmd.Parameters.AddWithValue("@TitularName", item.TitularNameDao);
                cmd.Parameters.AddWithValue("@TitularPosition", item.TitularPositionDao);
                cmd.Parameters.AddWithValue("@AdvisoryName", item.AdvisoryNameDao);
                cmd.Parameters.AddWithValue("@AdvisoryPosition", item.AdvisoryPositionDao);
                cmd.Parameters.AddWithValue("@AgreedName", item.AgreedNameDao);
                cmd.Parameters.AddWithValue("@Agreed", item.AgreedDao);
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


        public static Company GetItem(int id)
        {
            MySqlConnection conn = Conection.getConnection();
            Company item = null;
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM companies WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new Company(Convert.ToInt32(reader["id"]), Convert.ToString(reader["comp_name"]),
                        Convert.ToString(reader["RFC"]), Convert.ToString(reader["turn"]),
                         Convert.ToString(reader["companyHome"]), Convert.ToString(reader["companyColony"]), Convert.ToString(reader["cp"])
                         , Convert.ToString(reader["fax"]), Convert.ToString(reader["phoneCompany"]), Convert.ToString(reader["companyCity"]), Convert.ToString(reader["titularName"])
                         , Convert.ToString(reader["titularPosition"]), Convert.ToString(reader["advisoryName"]), Convert.ToString(reader["advisoryPosition"])
                         , Convert.ToString(reader["agreedName"]), Convert.ToString(reader["agreed"]));
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
