using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace InternshipControlSystem.Back_End
{
    class Conection
    {
        private static string conectionString = "server=localhost;user=admin;database=internships;port=3306;password=toor";
        private static MySqlConnection conn;

        private Conection() { }

        public static MySqlConnection getConnection()
        {
            if(conn == null)
            {
                return new MySqlConnection(conectionString);
            }
            return conn;
        }

    }
}
