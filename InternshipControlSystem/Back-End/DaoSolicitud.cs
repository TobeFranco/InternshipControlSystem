using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace InternshipControlSystem.Back_End

{
 public   class DaoSolicitud
    {
      



        //public int Agre(solicitud producto)
        //{
        //    String sentencia;
        //    try
        //    {
        //        sentencia = String.Format("INSERT INTO request(ProjectName,ChosenOption,ProjectedPeriod,NumberOfResidents,companyName,Turn,CompanyHome,RFC,CompanyColony,Cp,Fax,PhoneCompany,CompanyCity,TitularNameTitularPosition,AdvisoryName,AdvisoryPosition,AgreedName,Agreed,NameResident,NumberControl,Career,SocialSecurity,Home,NumberInsurance,Email,Phonehouse,City,Phone)"
        //            + "values(@P0,@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15,@P16,@P17,@P18,@P19,@P20,@P21,@P22,@P23,@P24,@P25,@26,@P27,@P28);");

        //        MySqlConnection onexion = Conection.getConnection();

        //        MySqlCommand cmd = new MySqlCommand(sentencia);
                
        //        cmd.Parameters.AddWithValue("@P0", producto.ProjectNameDao);
        //        cmd.Parameters.AddWithValue("@P1", producto.ChosenOptionDao);
        //        cmd.Parameters.AddWithValue("@P2", producto.ProjectedPeriodDao);
        //        cmd.Parameters.AddWithValue("@P3", producto.NumberOfResidentsDao);
        //        cmd.Parameters.AddWithValue("@P4", producto.companyNameDao);
        //        cmd.Parameters.AddWithValue("@P5", producto.TurnDao);
        //        cmd.Parameters.AddWithValue("@P6", producto.CompanyHomeDao);
        //        cmd.Parameters.AddWithValue("@P7", producto.RFCDao);
        //        cmd.Parameters.AddWithValue("@P8", producto.CompanyColonyDao);
        //        cmd.Parameters.AddWithValue("@P9", producto.CPDao);
        //        cmd.Parameters.AddWithValue("@P10", producto.FAXDao);  
        //        cmd.Parameters.AddWithValue("@P11", producto.PhoneCompanyDao);
        //        cmd.Parameters.AddWithValue("@P12", producto.CompanyCityDao);
        //        cmd.Parameters.AddWithValue("@P13", producto.TitularNameDao);
        //        cmd.Parameters.AddWithValue("@P14", producto.TitularPositionDao);
        //        cmd.Parameters.AddWithValue("@P15", producto.AdvisoryNameDao);
        //        cmd.Parameters.AddWithValue("@P16", producto.AdvisoryPositionDao);
        //        cmd.Parameters.AddWithValue("@P17", producto.AgreedNameDao);
        //        cmd.Parameters.AddWithValue("@P18", producto.AgreedDao);
        //        cmd.Parameters.AddWithValue("@P19", producto.NameResidentDao);
        //        cmd.Parameters.AddWithValue("@P20", producto.NumberControlDao);
        //        cmd.Parameters.AddWithValue("@P21", producto.CareerDao);
        //        cmd.Parameters.AddWithValue("@P22", producto.SocialSecurityDao);
        //        cmd.Parameters.AddWithValue("@P23", producto.HomeDao);
        //        cmd.Parameters.AddWithValue("@P24", producto.NumberInsuranceDao);
        //        cmd.Parameters.AddWithValue("@P25", producto.EmailDao);
        //        cmd.Parameters.AddWithValue("@P26", producto.PhonehouseDao);
        //        cmd.Parameters.AddWithValue("@P27", producto.CityDao);
        //        cmd.Parameters.AddWithValue("@P28", producto.PhoneDao);

        //        return onexion.ejecutarSentencia(cmd, true);
              
        //    }
        //    catch (Exception ex)
        //    {
        //        //return null;
        //        return 0;
        //    }
        //    finally
        //    {
        //        //Solo intentar cerrar la conexión cuando si se encuentra abierta
        //        if (Conexion.conexion != null)
        //        {
        //            Conexion.conexion.Close();
        //        }
        //    }
        //}



        public  void CreateItem(solicitud student)
        {
            MySqlConnection conn = Conection.getConnection();
            try
            {
                conn.Open();
                string sqlStatement = "INSERT INTO request VALUES(@id,@ProjectName,@ChosenOption,@ProjectedPeriod,@NumberOfResidents,@companyName,@Turn,@CompanyHome,@RFC,@CompanyColony,@Cp,@Fax,@PhoneCompany,@CompanyCity,@TitularName,@TitularPosition,@AdvisoryName,@AdvisoryPosition,@AgreedName,@Agreed,@NameResident,@NumberControl,@Career,@SocialSecurity,@Home,@NumberInsurance,@Email,@Phonehouse,@City,@Phone)";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@id", student.IdDao);
                cmd.Parameters.AddWithValue("@ProjectName", student.ProjectNameDao);
                cmd.Parameters.AddWithValue("@ChosenOption", student.ChosenOptionDao);
                cmd.Parameters.AddWithValue("@ProjectedPeriod", student.ProjectedPeriodDao);
                cmd.Parameters.AddWithValue("@NumberOfResidents", student.NumberOfResidentsDao);
                cmd.Parameters.AddWithValue("@companyName", student.companyNameDao);
                cmd.Parameters.AddWithValue("@Turn", student.TurnDao);
                cmd.Parameters.AddWithValue("@CompanyHome", student.CompanyHomeDao);
                cmd.Parameters.AddWithValue("@RFC", student.RFCDao);
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
                cmd.Parameters.AddWithValue("@NameResident", student.NameResidentDao);
                cmd.Parameters.AddWithValue("@NumberControl", student.NumberControlDao);
                cmd.Parameters.AddWithValue("@Career", student.CareerDao);
                cmd.Parameters.AddWithValue("@SocialSecurity", student.SocialSecurityDao);
                cmd.Parameters.AddWithValue("@Home", student.HomeDao);
                cmd.Parameters.AddWithValue("@NumberInsurance", student.NumberInsuranceDao);
                cmd.Parameters.AddWithValue("@Email", student.EmailDao);
                cmd.Parameters.AddWithValue("@Phonehouse", student.PhonehouseDao);
                cmd.Parameters.AddWithValue("@City", student.CityDao);
                cmd.Parameters.AddWithValue("@Phone", student.PhoneDao);
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

    }
}
