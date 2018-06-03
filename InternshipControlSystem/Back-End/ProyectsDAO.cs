using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using InternshipControlSystem.Model;

namespace InternshipControlSystem.Back_End
{
    class ProyectsDAO
    {
        public static List<Proyect> GetAllItems()
        {
            MySqlConnection conn = Conection.getConnection();
            List<Proyect> items = new List<Proyect>();
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM proyects";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Proyect item = new Proyect(Convert.ToInt32(reader["id"]), Convert.ToString(reader["pro_name"]),
                       Convert.ToInt32(reader["company_id"]), Convert.ToInt32(reader["student_id"]), Convert.ToString(reader["period"]),
                        Convert.ToString(reader["chosen_Option"]), Convert.ToInt32(reader["number_Of_Residents"]), Convert.ToInt32(reader["company_assessor_id"]));
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

        public static void CreateItem(Proyect item)
        {
            MySqlConnection conn = Conection.getConnection();
            try
            {
                conn.Open();
                string sqlStatement = "INSERT INTO projects VALUES(null, @pro_name, @company_id, @student_id, @period, @ChosenOption, @NumberOfResidents," +
                    "@CompanyAssessorId)";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@pro_name", item.Name);
                cmd.Parameters.AddWithValue("@company_id", item.Company_Id);
                cmd.Parameters.AddWithValue("@student_id", item.Student_Id);
                cmd.Parameters.AddWithValue("@period", item.Period);
                cmd.Parameters.AddWithValue("@ChosenOption", item.ChosenOptionDao);
                cmd.Parameters.AddWithValue("@NumberOfResidents", item.NumberOfResidentsDao);
                cmd.Parameters.AddWithValue("@CompanyAssessorId", item.companyAssesorId);
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
                string sqlStatement = "DELETE FROM projects WHERE id = @id";
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
                string sqlStatement = "UPDATE projects set pro_name=@pro_name, company_id=@company_id, student_id=@student_id" +
                    "period=@period, chosen_Option=@ChosenOption, number_Of_Residents=@NumberOfResidents, company_assessor_id=@CompanyAssessorId WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@pro_name", item.Name);
                cmd.Parameters.AddWithValue("@company_id", item.Company_Id);
                cmd.Parameters.AddWithValue("@student_id", item.Student_Id);
                cmd.Parameters.AddWithValue("@period", item.Period);
                cmd.Parameters.AddWithValue("@ChosenOption", item.ChosenOptionDao);
                cmd.Parameters.AddWithValue("@NumberOfResidents", item.NumberOfResidentsDao);
                cmd.Parameters.AddWithValue("@CompanyAssessorId", item.companyAssesorId);
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


        public static Proyect GetItem(int id)
        {
            MySqlConnection conn = Conection.getConnection();
            Proyect item = null;
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM projects WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new Proyect(Convert.ToInt32(reader["id"]), Convert.ToString(reader["pro_name"]),
                       Convert.ToInt32(reader["company_id"]), Convert.ToInt32(reader["student_id"]), Convert.ToString(reader["period"]),
                        Convert.ToString(reader["chosen_Option"]), Convert.ToInt32(reader["number_Of_Residents"]), Convert.ToInt32(reader["company_assessor_id"]));
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

        public static Proyect GetItem(Student student)
        {
            MySqlConnection conn = Conection.getConnection();
            Proyect item = null;
            try
            {
                conn.Open();
                string sqlStatement = "SELECT * FROM projects WHERE student_id = @student_id";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@student_id", student.Id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new Proyect(Convert.ToInt32(reader["id"]), Convert.ToString(reader["pro_name"]),
                       Convert.ToInt32(reader["company_id"]), Convert.ToInt32(reader["student_id"]), Convert.ToString(reader["period"]),
                        Convert.ToString(reader["chosen_Option"]), Convert.ToInt32(reader["number_Of_Residents"]), Convert.ToInt32(reader["company_assessor_id"]));
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
