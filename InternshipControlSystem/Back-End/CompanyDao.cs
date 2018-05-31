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
                    Company item = new Company(Convert.ToInt32(reader["id"]), Convert.ToString(reader["first_name"]),
                        Convert.ToString(reader["RFC"]), Convert.ToString(reader["Turn"]),
                         Convert.ToString(reader["CompanyHome"]), Convert.ToString(reader["CompanyColony"]), Convert.ToString(reader["Cp"])
                         , Convert.ToString(reader["Fax"]), Convert.ToString(reader["PhoneCompany"]), Convert.ToString(reader["CompanyCity"]), Convert.ToString(reader["TitularName"])
                         , Convert.ToString(reader["TitularPosition"]), Convert.ToString(reader["AdvisoryName"]), Convert.ToString(reader["AdvisoryPosition"])
                         , Convert.ToString(reader["AgreedName "]), Convert.ToString(reader["Agreed"]));
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

        public static int CreateItem(Company student)
        {
            MySqlConnection conn = Conection.getConnection();
            try
            {
                conn.Open();
                string sqlStatement = "INSERT INTO companies VALUES(null, @comp_name, @RFC, @Turn, @CompanyHome, @CompanyColony, @Cp, @Fax, @PhoneCompany, @CompanyCity, @TitularName, @TitularPosition, @AdvisoryName, @AdvisoryPosition, @AgreedName, @Agreed); SELECT LAST_INSERT_ID()";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@comp_name", student.Name);
                cmd.Parameters.AddWithValue("@RFC", student.RFC);              
                cmd.Parameters.AddWithValue("@Turn", student.TurnDao);
                cmd.Parameters.AddWithValue("@CompanyHome", student.CompanyHomeDao);            
                cmd.Parameters.AddWithValue("@CompanyColony", student.CompanyColonyDao);
                cmd.Parameters.AddWithValue("@Cp", student.CPDao);
                cmd.Parameters.AddWithValue("@Fax", student.FAXDao);
                cmd.Parameters.AddWithValue("@PhoneCompany", student.PhoneCompanyDao);
                cmd.Parameters.AddWithValue("@CompanyCity", student.CompanyCityDao);
                cmd.Parameters.AddWithValue("@TitularName", student.TitularNameDao);
                cmd.Parameters.AddWithValue("@TitularPosition", student.TitularPositionDao);
                cmd.Parameters.AddWithValue("@AdvisoryName", student.AdvisoryNameDao);
                cmd.Parameters.AddWithValue("@AdvisoryPosition", student.AdvisoryPositionDao);
                cmd.Parameters.AddWithValue("@AgreedName", student.AgreedNameDao);
                cmd.Parameters.AddWithValue("@Agreed", student.AgreedDao);
                cmd.Parameters.AddWithValue("@company_id", student.AgreedDao);
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

        public static void UpdateItem(Proyect item)
        {
            MySqlConnection conn = Conection.getConnection();
            try
            {
                conn.Open();
                string sqlStatement = "UPDATE proyects set pro_name=@pro_name, company_id=@company_id, student_id=@student_id" +
                    "period=@period WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.Parameters.AddWithValue("@pro_name", item.Name);
                cmd.Parameters.AddWithValue("@company_id", item.Company_Id);
                cmd.Parameters.AddWithValue("@student_id", item.Student_Id);
                cmd.Parameters.AddWithValue("@period", item.Period);
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


        //public static Company GetItem(int id)
        //{
        //    MySqlConnection conn = Conection.getConnection();
        //   Company item = null;
        //    try
        //    {
        //        conn.Open();
        //        string sqlStatement = "SELECT * FROM companies WHERE id = @id";
        //        MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
        //        cmd.Parameters.AddWithValue("@id", id);
        //        MySqlDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            Company item = new Company(Convert.ToInt32(reader["id"]), Convert.ToString(reader["first_name"]),
        //                       Convert.ToString(reader["RFC"]), Convert.ToInt32(reader["company_assessor_id"]), Convert.ToString(reader["Turn"]),
        //                        Convert.ToString(reader["CompanyHome"]), Convert.ToString(reader["CompanyColony"]), Convert.ToString(reader["Cp"])
        //                        , Convert.ToString(reader["Fax"]), Convert.ToString(reader["PhoneCompany"]), Convert.ToString(reader["CompanyCity"]), Convert.ToString(reader["TitularName"])
        //                        , Convert.ToString(reader["TitularPosition"]), Convert.ToString(reader["AdvisoryName"]), Convert.ToString(reader["AdvisoryPosition"])
        //                        , Convert.ToString(reader["AgreedName "]), Convert.ToString(reader["Agreed"]));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return item;
        //}

        //public static Company GetItem(Student student)
        //{
        //    MySqlConnection conn = Conection.getConnection();
        //    Company item = null;
        //    try
        //    {
        //        conn.Open();
        //        string sqlStatement = "SELECT * FROM proyects WHERE student_id = @student_id";
        //        MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
        //        cmd.Parameters.AddWithValue("@student_id", student.Id);
        //        MySqlDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            Company item = new Company(Convert.ToInt32(reader["id"]), Convert.ToString(reader["first_name"]),
        //                Convert.ToString(reader["RFC"]), Convert.ToInt32(reader["company_assessor_id"]), Convert.ToString(reader["Turn"]),
        //                 Convert.ToString(reader["CompanyHome"]), Convert.ToString(reader["CompanyColony"]), Convert.ToString(reader["Cp"])
        //                 , Convert.ToString(reader["Fax"]), Convert.ToString(reader["PhoneCompany"]), Convert.ToString(reader["CompanyCity"]), Convert.ToString(reader["TitularName"])
        //                 , Convert.ToString(reader["TitularPosition"]), Convert.ToString(reader["AdvisoryName"]), Convert.ToString(reader["AdvisoryPosition"])
        //                 , Convert.ToString(reader["AgreedName "]), Convert.ToString(reader["Agreed"]));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return item;
        //}

    }
}
